using Domain.Entities;
using Domain.UnitOfWork;

namespace Scorerecord.Services
{
    public interface IIndustryService
    {
        public Task<IEnumerable<Industry>> GetAll();
        public Task<Industry> AddIndustry(Industry model);
        public Task<bool> UpdateIndustry(Guid id, Industry model);
        public Task<bool> DeleteIndustry(Guid id);
        public Task<Industry> GetAsync(Guid accountId);
    }
    public class IndustryService : IIndustryService
    {
        public IUnitOfWork _unitOfWork;
        public IndustryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Industry> AddIndustry(Industry model)
        {
            try
            {
                var industry = new Industry
                {
                    Id = Guid.NewGuid(),
                    Name = model.Name,
                    CreatedDate = DateTime.Now,
                    CreatedBy = "1",
                    Status = "Active"
                };
                _unitOfWork.IndustryRepository.Add(industry);
                await _unitOfWork.CommitAsync();
                return industry;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> DeleteIndustry(Guid id)
        {
            try
            {
                var existIndustry = _unitOfWork.IndustryRepository.Get(a => a.Id == id);
                if (existIndustry == null)
                    return false;
                existIndustry.Status = "Deleted";
                existIndustry.ModifiedDate = DateTime.Now;
                _unitOfWork.IndustryRepository.Update(existIndustry);
                await _unitOfWork.CommitAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<Industry>> GetAll()
        {
            return await _unitOfWork.IndustryRepository.GetAllAsync(a => a.Status == "Active");
        }

        public async Task<Industry> GetAsync(Guid id)
        {
            return (await _unitOfWork.IndustryRepository.GetAsync(a => a.Id == id));
        }

        public async Task<bool> UpdateIndustry(Guid id, Industry model)
        {
            try
            {
                var existIndustry = _unitOfWork.IndustryRepository.Get(a => a.Id == id);
                if (existIndustry == null)
                    return false;
                existIndustry.Name = model.Name;
                existIndustry.ModifiedDate = DateTime.Now;
                _unitOfWork.IndustryRepository.Update(existIndustry);
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
