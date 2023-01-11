using Domain.Common;
using Domain.Entities;
using Domain.UnitOfWork;
using Infrastructure.Shared.Services;

namespace Scorerecord.Services
{
    
    public interface IMemberService
    {
        public Task<IEnumerable<Member>> GetAllByRole(Roles role);
        public Task<IEnumerable<Member>> GetAll();
        public Task<Member> AddMember(Member model);
        public Task<bool> UpdateMember(Guid id, Member model);
        public Task<bool> PasswordReset(Guid id, string password);
        public Task<bool> DeleteMember(Guid id);
        public bool IsExistUserName(string email);
        public Task<Member> GetAsync(Guid id);
        public Member Login(string Email, string Password);
        public Member GetByEmail(string Email);
    }
    public class MemberService : IMemberService
    {
        public IUnitOfWork _unitOfWork;
        public MemberService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Member> AddMember(Member model)
        {
            try
            {
                var member = new Member
                {
                    Id = Guid.NewGuid(),
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Mobile = model.Mobile,
                    Password = model.Password,
                    CreatedDate = DateTime.Now,
                    CreatedBy = "1",
                    Status = "Active"
                };
                _unitOfWork.MemberRepository.Add(member);
                await _unitOfWork.CommitAsync();
                return member;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> DeleteMember(Guid id)
        {
            try
            {
                var existMember = _unitOfWork.MemberRepository.Get(a => a.Id == id);
                if (existMember == null)
                    return false;
                existMember.Status = "Deleted";
                existMember.ModifiedDate = DateTime.Now;
                _unitOfWork.MemberRepository.Update(existMember);
                await _unitOfWork.CommitAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<Member>> GetAllByRole(Roles role)
        {
            return await _unitOfWork.MemberRepository.GetAllAsync(a => a.Status == "Active" && a.Roles==role);
        }
        public async Task<IEnumerable<Member>> GetAll()
        {
            return await _unitOfWork.MemberRepository.GetAllAsync(a => a.Status == "Active");
        }

        public async Task<Member> GetAsync(Guid id)
        {
            return (await _unitOfWork.MemberRepository.GetAsync(a => a.Id == id));
        }
        public bool IsExistUserName(string email)
        {
            try
            {
                return _unitOfWork.MemberRepository.IsExist(a => a.Email == email && a.Status == "Active");
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> PasswordReset(Guid id,string password)
        {
            try
            {
               var existMember = _unitOfWork.MemberRepository.Get(a => a.Id == id && a.Status == "Active");
                existMember.Password = HashConfig.GetHash(password);
                _unitOfWork.MemberRepository.Update(existMember);
                await _unitOfWork.CommitAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public Member Login(string email, string password)
        {
            try
            {
                string hassPassword = HashConfig.GetHash(password);
                return  _unitOfWork.MemberRepository.Get(s => s.Email == email && s.Password == hassPassword && s.Status == "Active");
            }
            catch
            {
                return null;
            }
        }
        public Member GetByEmail(string Email)
        {
            try
            {
                return _unitOfWork.MemberRepository.Get(s => s.Email == Email && s.Status=="Active");
            }
            catch
            {
                return null;
            }
        }
        public async Task<bool> UpdateMember(Guid id, Member model)
        {
            try
            {
                var existMember = _unitOfWork.MemberRepository.Get(a => a.Id == id);
                if (existMember == null)
                    return false;
                existMember.FirstName = model.FirstName;
                existMember.LastName = model.LastName;
                existMember.Email = model.Email;
                existMember.Mobile = model.Mobile;
                existMember.Image = model.Image;
                existMember.OTP = model.OTP;
                existMember.ModifiedDate = DateTime.Now;
                _unitOfWork.MemberRepository.Update(existMember);
                await _unitOfWork.CommitAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
