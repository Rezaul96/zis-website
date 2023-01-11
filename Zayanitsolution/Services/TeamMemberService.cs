using Domain.Entities;
using Domain.UnitOfWork;

namespace Scorerecord.Services
{
    
    public interface ITeamMemberService
    {
        public Task<IEnumerable<TeamMember>> GetAll();
        public Task<TeamMember> AddTeamMember(TeamMember model);
        public Task<bool> UpdateTeamMember(Guid id, TeamMember model);
        public Task<bool> DeleteTeamMember(Guid id);
        public Task<TeamMember> GetAsync(Guid accountId);
    }
    public class TeamMemberService : ITeamMemberService
    {
        public IUnitOfWork _unitOfWork;
        public TeamMemberService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<TeamMember> AddTeamMember(TeamMember model)
        {
            try
            {
                var teamMember = new TeamMember
                {
                    Id = Guid.NewGuid(),
                    Name = model.Name,
                    Email = model.Email,
                    TeamId = model.TeamId,
                    CreatedDate = DateTime.Now,
                    CreatedBy = "1",
                    Status = "Active"
                };
                _unitOfWork.TeamMemberRepository.Add(teamMember);
                await _unitOfWork.CommitAsync();
                return teamMember;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> DeleteTeamMember(Guid id)
        {
            try
            {
                var existTeamMember = _unitOfWork.TeamMemberRepository.Get(a => a.Id == id);
                if (existTeamMember == null)
                    return false;
                existTeamMember.Status = "Deleted";
                existTeamMember.ModifiedDate = DateTime.Now;
                _unitOfWork.TeamMemberRepository.Update(existTeamMember);
                await _unitOfWork.CommitAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<TeamMember>> GetAll()
        {
            return await _unitOfWork.TeamMemberRepository.GetAllAsync(a => a.Status == "Active");
        }

        public async Task<TeamMember> GetAsync(Guid id)
        {
            return (await _unitOfWork.TeamMemberRepository.GetAsync(a => a.Id == id));
        }

        public async Task<bool> UpdateTeamMember(Guid id, TeamMember model)
        {
            try
            {
                var existTeamMember = _unitOfWork.TeamMemberRepository.Get(a => a.Id == id);
                if (existTeamMember == null)
                    return false;
                existTeamMember.TeamId = model.TeamId;
                existTeamMember.Email = model.Email;
                existTeamMember.Name = model.Name;
               
                existTeamMember.ModifiedDate = DateTime.Now;
                _unitOfWork.TeamMemberRepository.Update(existTeamMember);
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
