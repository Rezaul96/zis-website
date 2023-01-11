using Domain.Entities;
using Domain.UnitOfWork;

namespace Scorerecord.Services
{
    public interface IObjectTypeService
    {
        public Task<IEnumerable<ObjectType>> GetAll();
        public Task<ObjectType> AddObjectType(ObjectType model);
        public Task<bool> UpdateObjectType(Guid id, ObjectType model);
        public Task<bool> DeleteObjectType(Guid id);
        public Task<ObjectType> GetAsync(Guid accountId);
    }
    public class ObjectTypeService : IObjectTypeService
    {
        public IUnitOfWork _unitOfWork;
        public ObjectTypeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ObjectType> AddObjectType(ObjectType model)
        {
            try
            {
                var objectType = new ObjectType
                {
                    Id = Guid.NewGuid(),
                    Name = model.Name,
                    IsScoring = model.IsScoring,
                    CreatedDate = DateTime.Now,
                    CreatedBy = "1",
                    Status = "Active"
                };
                _unitOfWork.ObjectTypeRepository.Add(objectType);
                await _unitOfWork.CommitAsync();
                return objectType;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> DeleteObjectType(Guid id)
        {
            try
            {
                var existObjectType = _unitOfWork.ObjectTypeRepository.Get(a => a.Id == id);
                if (existObjectType == null)
                    return false;
                existObjectType.Status = "Deleted";
                existObjectType.ModifiedDate = DateTime.Now;
                _unitOfWork.ObjectTypeRepository.Update(existObjectType);
                await _unitOfWork.CommitAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<ObjectType>> GetAll()
        {
            return await _unitOfWork.ObjectTypeRepository.GetAllAsync(a => a.Status == "Active");
        }

        public async Task<ObjectType> GetAsync(Guid id)
        {
            return (await _unitOfWork.ObjectTypeRepository.GetAsync(a => a.Id == id));
        }

        public async Task<bool> UpdateObjectType(Guid id, ObjectType model)
        {
            try
            {
                var existObjectType = _unitOfWork.ObjectTypeRepository.Get(a => a.Id == id);
                if (existObjectType == null)
                    return false;
                existObjectType.Name = model.Name;
                existObjectType.IsScoring = model.IsScoring;
                existObjectType.ModifiedDate = DateTime.Now;
                _unitOfWork.ObjectTypeRepository.Update(existObjectType);
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
