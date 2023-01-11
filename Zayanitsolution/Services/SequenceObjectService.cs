using Domain.Entities;
using Domain.UnitOfWork;

namespace Scorerecord.Services
{
    public interface ISequenceObjectService
    {
        public Task<SequenceObject> AddSequenceObject(SequenceObject model);
        public Task<bool> UpdateSequenceObject(Guid id, SequenceObject model);
        public Task<bool> DeleteSequenceObject(Guid id);
        public Task<SequenceObject> GetAsync(Guid accountId);
        public Task<IEnumerable<SequenceObject>> GetAllBySequenceId(Guid sequenceId);
        public Task<IEnumerable<SequenceObject>> GetAllByEventObjectId(Guid eventObjectId);

    }
    public class SequenceObjectService : ISequenceObjectService
    {
        public IUnitOfWork _unitOfWork;
        public SequenceObjectService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<SequenceObject> AddSequenceObject(SequenceObject model)
        {
            try
            {
                var sequenceObject = new SequenceObject
                {
                    Id = Guid.NewGuid(),
                    IsLoginEventObject = model.IsLoginEventObject,
                    EventObjectId = model.EventObjectId,
                    SequenceId = model.SequenceId,
                    Position = model.Position
                };
                _unitOfWork.SequenceObjectRepository.Add(sequenceObject);
                await _unitOfWork.CommitAsync();
                return sequenceObject;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> DeleteSequenceObject(Guid id)
        {
            try
            {
                var existSequenceObject = _unitOfWork.SequenceObjectRepository.Get(a => a.Id == id);
                if (existSequenceObject == null)
                    return false;
                _unitOfWork.SequenceObjectRepository.Remove(existSequenceObject);
                await _unitOfWork.CommitAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<SequenceObject>> GetAllByEventObjectId(Guid eventObjectId)
        {
            return await _unitOfWork.SequenceObjectRepository.GetAllAsync(a => a.EventObjectId == eventObjectId);
        }
        public async Task<IEnumerable<SequenceObject>> GetAllBySequenceId(Guid sequenceId)
        {
            return await _unitOfWork.SequenceObjectRepository.GetAllAsync(a => a.SequenceId == sequenceId);
        }
        public async Task<SequenceObject> GetAsync(Guid id)
        {
            return (await _unitOfWork.SequenceObjectRepository.GetAsync(a => a.Id == id));
        }
       
        public async Task<bool> UpdateSequenceObject(Guid id, SequenceObject model)
        {
            try
            {
                var existSequenceObject = _unitOfWork.SequenceObjectRepository.Get(a => a.Id == id);
                if (existSequenceObject == null)
                    return false;
                existSequenceObject.Position = model.Position;
                _unitOfWork.SequenceObjectRepository.Update(existSequenceObject);
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
