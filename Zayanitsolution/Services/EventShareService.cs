using Domain.Entities;
using Domain.UnitOfWork;

namespace Scorerecord.Services
{

    public interface IEventShareService
    {
        public Task<IEnumerable<EventShare>> GetAll();
        public Task<EventShare> AddEventShare(EventShare model);
        public Task<bool> DeleteEventShare(Guid id);
        public Task<EventShare> GetAsync(Guid accountId);
    }
    public class EventShareService : IEventShareService
    {
        public IUnitOfWork _unitOfWork;
        public EventShareService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<EventShare> AddEventShare(EventShare model)
        {
            try
            {
                var EventShare = new EventShare
                {
                    Id = Guid.NewGuid(),
                    EventObjectId = model.EventObjectId,
                    MemberId = model.MemberId

                };
                _unitOfWork.EventShareRepository.Add(EventShare);
                await _unitOfWork.CommitAsync();
                return EventShare;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> DeleteEventShare(Guid id)
        {
            try
            {
                var existEventShare = _unitOfWork.EventShareRepository.Get(a => a.Id == id);
                if (existEventShare == null)
                    return false;
                _unitOfWork.EventShareRepository.Remove(existEventShare);
                await _unitOfWork.CommitAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<EventShare>> GetAll()
        {
            return await _unitOfWork.EventShareRepository.GetAllAsync();
        }

        public async Task<EventShare> GetAsync(Guid id)
        {
            return (await _unitOfWork.EventShareRepository.GetAsync(a => a.Id == id));
        }

   
    }
}
