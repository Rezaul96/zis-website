using Domain.Entities;
using Domain.UnitOfWork;

namespace Scorerecord.Services
{
    public interface ICompanyService
    {
        public Task<IEnumerable<Company>> GetAll();
        public Task<Company> AddCompany(Company model);
        public Task<bool> UpdateCompany(Guid id, Company model);
        public Task<bool> DeleteCompany(Guid id);
        public Task<Company> GetAsync(Guid accountId);
    }
    public class CompanyService : ICompanyService
    {
        public IUnitOfWork _unitOfWork;
        public CompanyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Company> AddCompany(Company model)
        {
            try
            {
                var company = new Company
                {
                    Id = Guid.NewGuid(),
                    Name = model.Name,
                    AboutUs = model.AboutUs,
                    IndustryId = model.IndustryId,
                    Logo=model.Logo,
                    RegionId = model.RegionId,
                    CreatedDate = DateTime.Now,
                    CreatedBy = "1",
                    Status = "Active"
                };
                _unitOfWork.CompanyRepository.Add(company);
                await _unitOfWork.CommitAsync();
                return company;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> DeleteCompany(Guid id)
        {
            try
            {
                var existCompany = _unitOfWork.CompanyRepository.Get(a => a.Id == id);
                if (existCompany == null)
                    return false;
                existCompany.Status = "Deleted";
                existCompany.ModifiedDate = DateTime.Now;
                _unitOfWork.CompanyRepository.Update(existCompany);
                await _unitOfWork.CommitAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<Company>> GetAll()
        {
            return await _unitOfWork.CompanyRepository.GetAllAsync(a => a.Status == "Active");
        }

        public async Task<Company> GetAsync(Guid id)
        {
            return (await _unitOfWork.CompanyRepository.GetAsync(a => a.Id == id));
        }

        public async Task<bool> UpdateCompany(Guid id, Company model)
        {
            try
            {
                var existCompany = _unitOfWork.CompanyRepository.Get(a => a.Id == id);
                if (existCompany == null)
                    return false;
                existCompany.RegionId = model.RegionId;
                existCompany.IndustryId = model.IndustryId;
                existCompany.Name = model.Name;
                existCompany.AboutUs = model.AboutUs;
                existCompany.Logo = model.Logo;
                existCompany.ModifiedDate = DateTime.Now;
                _unitOfWork.CompanyRepository.Update(existCompany);
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
