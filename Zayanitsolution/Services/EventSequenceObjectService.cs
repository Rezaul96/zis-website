using Domain.Entities;
using Domain.UnitOfWork;

namespace Scorerecord.Services
{
  
    public interface IEventSequenceObjectService
    {
        public Task<EventSequenceObject> GetLoginEventSequenceObjectBySequenceId(Guid sequenceId);
        public Task<EventSequenceObject> AddEventSequenceObject(EventSequenceObject model);
        public Task<bool> UpdateEventSequenceObject(Guid id, EventSequenceObject model);
        public Task<bool> DeleteEventSequenceObject(Guid id);
        public Task<EventSequenceObject> GetAsync(Guid accountId);
        public Task<IEnumerable<EventSequenceObject>> GetAllBySequenceId(Guid sequenceId);
        public Task<IEnumerable<EventSequenceObject>> GetAllByEventObjectId(Guid eventObjectId);

    }
    public class EventSequenceObjectService : IEventSequenceObjectService
    {
        public IUnitOfWork _unitOfWork;
        public EventSequenceObjectService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<EventSequenceObject> AddEventSequenceObject(EventSequenceObject model)
        {
            try
            {
                var eventSequenceObject = new EventSequenceObject
                {
                    Id = Guid.NewGuid(),
                    IsLoginEventObject = model.IsLoginEventObject,
                    EventObjectId = model.EventObjectId,
                    SequenceId = model.SequenceId,
                    Position = model.Position,
                    ActivityStatus = model.ActivityStatus,
                    EventId = model.EventId,
                    SequenceObjectId = model.SequenceObjectId
                };
                _unitOfWork.EventSequenceObjectRepository.Add(eventSequenceObject);
                await _unitOfWork.CommitAsync();
                return eventSequenceObject;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> DeleteEventSequenceObject(Guid id)
        {
            try
            {
                var existEventSequenceObject = _unitOfWork.EventSequenceObjectRepository.Get(a => a.Id == id);
                if (existEventSequenceObject == null)
                    return false;
                _unitOfWork.EventSequenceObjectRepository.Remove(existEventSequenceObject);
                await _unitOfWork.CommitAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<EventSequenceObject>> GetAllByEventObjectId(Guid eventObjectId)
        {
            return await _unitOfWork.EventSequenceObjectRepository.GetAllAsync(a => a.EventObjectId == eventObjectId);
        }
        public async Task<IEnumerable<EventSequenceObject>> GetAllBySequenceId(Guid sequenceId)
        {
            return await _unitOfWork.EventSequenceObjectRepository.GetAllAsync(a => a.SequenceId == sequenceId);
        }
        public async Task<EventSequenceObject> GetAsync(Guid id)
        {
            return (await _unitOfWork.EventSequenceObjectRepository.GetAsync(a => a.Id == id));
        }
        public async Task<EventSequenceObject> GetLoginEventSequenceObjectBySequenceId(Guid sequenceId)
        {
            return (await _unitOfWork.EventSequenceObjectRepository.GetAsync(a => a.SequenceId == sequenceId && a.IsLoginEventObject));
        }
        public async Task<bool> UpdateEventSequenceObject(Guid id, EventSequenceObject model)
        {
            try
            {
                var existEventSequenceObject = _unitOfWork.EventSequenceObjectRepository.Get(a => a.Id == id);
                if (existEventSequenceObject == null)
                    return false;
                existEventSequenceObject.Position = model.Position;
                existEventSequenceObject.ActivityStatus = model.ActivityStatus;
                _unitOfWork.EventSequenceObjectRepository.Update(existEventSequenceObject);
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
