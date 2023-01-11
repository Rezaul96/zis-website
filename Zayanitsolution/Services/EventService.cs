using Domain.Entities;
using Domain.UnitOfWork;

namespace Scorerecord.Services
{
   
    public interface IEventService
    {
        public Task<IEnumerable<Event>> GetAll();
        public Task<Event> AddEvent(Event model);
        public Task<bool> UpdateEvent(Guid id, Event model);
        public Task<bool> DeleteEvent(Guid id);
        public Task<Event> GetAsync(Guid id);
    }
    public class EventService : IEventService
    {
        public IUnitOfWork _unitOfWork;
        public EventService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
      
        public async Task<Event> AddEvent(Event model)
        {
            try
            {
                var events = new Event
                {
                    Id = Guid.NewGuid(),
                    Name = model.Name,
                    CompanyId = model.CompanyId,
                    SequenceId = model.SequenceId,
                    QrCode = model.QrCode,
                    EventCode = model.EventCode,
                    EventDate = model.EventDate,
                    Description = model.Description,
                    CustomRedirectUrl = model.CustomRedirectUrl,
                    Icon = model.Icon,
                    HoldingScreanImage = model.HoldingScreanImage,
                    CreatedDate = DateTime.Now,
                    CreatedBy = "1",
                    Status = "Active"
                };
                _unitOfWork.EventRepository.Add(events);

                var sequenceObject = _unitOfWork.SequenceObjectRepository.GetAll(a=>a.SequenceId==model.SequenceId);
                foreach(var sequence in sequenceObject)
                {
                    var eventSequence = new EventSequenceObject
                    {
                        Id = Guid.NewGuid(),
                        EventObjectId = sequence.EventObjectId,
                        SequenceId = sequence.SequenceId,
                        EventId = events.Id,
                        SequenceObjectId = sequence.Id,
                        Position = sequence.Position,
                        IsLoginEventObject = sequence.IsLoginEventObject
                    };
                    _unitOfWork.EventSequenceObjectRepository.Add(eventSequence);
                }
                await _unitOfWork.CommitAsync();
                return events;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> DeleteEvent(Guid id)
        {
            try
            {
                var existEvent = _unitOfWork.EventRepository.Get(a => a.Id == id);
                if (existEvent == null)
                    return false;
                existEvent.Status = "Deleted";
                existEvent.ModifiedDate = DateTime.Now;
                _unitOfWork.EventRepository.Update(existEvent);
                await _unitOfWork.CommitAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<Event>> GetAll()
        {
            return await _unitOfWork.EventRepository.GetAllAsync(a => a.Status == "Active");
        }

        public async Task<Event> GetAsync(Guid id)
        {
            return await _unitOfWork.EventRepository.GetAsync(a => a.Id == id);
        }

        public async Task<bool> UpdateEvent(Guid id, Event model)
        {
            try
            {
                var existEvent = _unitOfWork.EventRepository.Get(a => a.Id == id);
                if (existEvent == null)
                    return false;
                existEvent.CompanyId = model.CompanyId;
                existEvent.SequenceId = model.SequenceId;
                existEvent.Name = model.Name;
                existEvent.EventCode = model.EventCode;
                existEvent.EventDate = model.EventDate;
                existEvent.Description = model.Description;
                existEvent.CustomRedirectUrl = model.CustomRedirectUrl;
                existEvent.Icon = model.Icon;
                existEvent.HoldingScreanImage = model.HoldingScreanImage;
                existEvent.ModifiedDate = DateTime.Now;
                _unitOfWork.EventRepository.Update(existEvent);
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
