using Domain.Entities;
using Domain.UnitOfWork;

namespace Scorerecord.Services
{
 
    public interface IRegionService
    {
        public Task<IEnumerable<Region>> GetAll();
        public Task<Region> AddRegion(Region model);
        public Task<bool> UpdateRegion(Guid id, Region model);
        public Task<bool> DeleteRegion(Guid id);
        public Task<Region> GetAsync(Guid accountId);
    }
    public class RegionService : IRegionService
    {
        public IUnitOfWork _unitOfWork;
        public RegionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Region> AddRegion(Region model)
        {
            try
            {
                var region = new Region
                {
                    Id = Guid.NewGuid(),
                    Name = model.Name,
                    CreatedDate = DateTime.Now,
                    CreatedBy = "1",
                    Status = "Active"
                };
                _unitOfWork.RegionRepository.Add(region);
                await _unitOfWork.CommitAsync();
                return region;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> DeleteRegion(Guid id)
        {
            try
            {
                var existRegion = _unitOfWork.RegionRepository.Get(a => a.Id == id);
                if (existRegion == null)
                    return false;
                existRegion.Status = "Deleted";
                existRegion.ModifiedDate = DateTime.Now;
                _unitOfWork.RegionRepository.Update(existRegion);
                await _unitOfWork.CommitAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<Region>> GetAll()
        {
            return await _unitOfWork.RegionRepository.GetAllAsync(a => a.Status == "Active");
        }

        public async Task<Region> GetAsync(Guid id)
        {
            return (await _unitOfWork.RegionRepository.GetAsync(a => a.Id == id));
        }

        public async Task<bool> UpdateRegion(Guid id, Region model)
        {
            try
            {
                var existRegion = _unitOfWork.RegionRepository.Get(a => a.Id == id);
                if (existRegion == null)
                    return false;
                existRegion.Name = model.Name;
                existRegion.ModifiedDate = DateTime.Now;
                _unitOfWork.RegionRepository.Update(existRegion);
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
