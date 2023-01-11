using Domain.Entities;
using Domain.UnitOfWork;
using Scorerecord.Helper;

namespace Scorerecord.Services
{

    public interface IEventObjectService
    {
        public Task<IEnumerable<EventObject>> GetAll();
        public List<EventObject> GetAllBySequenceId(Guid sequenceId);
        public Task<EventObject> AddEventObject(EventObject model);
        public Task<bool> UpdateEventObject(Guid id, EventObject model);
        public Task<bool> DeleteEventObject(Guid id);
        public Task<EventObject> GetAsync(Guid accountId);
    }
    public class EventObjectService : IEventObjectService
    {
        public IUnitOfWork _unitOfWork;
        public EventObjectService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<EventObject> GetAllBySequenceId(Guid sequenceId)
        {
            var sequenceObject = from sr in _unitOfWork.EventSequenceObjectRepository.GetAll(a => a.SequenceId == sequenceId).OrderBy(a => a.Position)
                                 select new EventObject
                                 {
                                     CreatedBy = sr.EventObjects.CreatedBy,
                                     Id = sr.EventObjects.Id,
                                     CreatedDate = sr.EventObjects.CreatedDate,
                                     Description = sr.EventObjects.Description,
                                     IsActivityTime = sr.EventObjects.IsActivityTime,
                                     IsAverageSpeed = sr.EventObjects.IsAverageSpeed,
                                     ModifiedBy = sr.EventObjects.ModifiedBy,
                                     ModifiedDate = sr.EventObjects.ModifiedDate,
                                     ObjectName = sr.EventObjects.ObjectName,
                                     ObjectStatus = sr.ActivityStatus,
                                     ObjectTypeId = sr.EventObjects.ObjectTypeId,
                                     ObjectTypes = sr.EventObjects.ObjectTypes,
                                     Product = sr.EventObjects.Product,
                                     Scoring = sr.EventObjects.Scoring,
                                     Share = sr.EventObjects.Share,
                                     Status = sr.EventObjects.Status,
                                     Title = sr.EventObjects.Title,
                                     IsLoginEventObject = sr.IsLoginEventObject,
                                 };
            return sequenceObject.ToList();
        }
        public async Task<EventObject> AddEventObject(EventObject model)
        {
            try
            {
                var eventObject = new EventObject
                {
                    Id = Guid.NewGuid(),
                    ObjectTypeId = model.ObjectTypeId,
                    ObjectName = model.ObjectName,
                    Title = model.Title,
                    Description = model.Description,
                    Product = model.Product,
                    Share = model.MemberId.Count() > 0 ? true : false,
                    Scoring = model.Scoring,
                    IsActivityTime = model.IsActivityTime,
                    IsAverageSpeed = model.IsAverageSpeed,
                    CreatedDate = DateTime.Now,
                    CreatedBy = "1",
                    Status = "Active"
                };
                _unitOfWork.EventObjectRepository.Add(eventObject);

                foreach (var memberId in model.MemberId)
                {
                    var eventShrae = new EventShare
                    {
                        Id = Guid.NewGuid(),
                        EventObjectId = eventObject.Id,
                        MemberId = memberId,
                    };
                    _unitOfWork.EventShareRepository.Add(eventShrae);
                }
                if (model.ParticipantActiveImage != null)
                {
                    var participantImage = new ParticipantImage
                    {
                        ActivityStatus = Domain.Common.ActivityStatus.Active,
                        Id = Guid.NewGuid(),
                        CreatedBy = "1",
                        CreatedDate = DateTime.Now,
                        EventObjectId = eventObject.Id,
                        Status = "Active",
                        FontColor = model.ParticipantActive,
                        ImageUrl = MediaHelper.UploadLargeFile(model.ParticipantActiveImage, "Content/Upload/ParticipantImage")
                    };
                    _unitOfWork.ParticipantImageRepository.Add(participantImage);

                }
                if (model.ParticipantReadyImage != null)
                {
                    var participantImage = new ParticipantImage
                    {
                        ActivityStatus = Domain.Common.ActivityStatus.Ready,
                        Id = Guid.NewGuid(),
                        CreatedBy = "1",
                        CreatedDate = DateTime.Now,
                        EventObjectId = eventObject.Id,
                        Status = "Active",
                        FontColor = model.ParticipantReady,
                        ImageUrl = MediaHelper.UploadLargeFile(model.ParticipantReadyImage, "Content/Upload/ParticipantImage")
                    };
                    _unitOfWork.ParticipantImageRepository.Add(participantImage);

                }
                if (model.ParticipantCompleteImage != null)
                {
                    var participantImage = new ParticipantImage
                    {
                        ActivityStatus = Domain.Common.ActivityStatus.Complete,
                        Id = Guid.NewGuid(),
                        CreatedBy = "1",
                        CreatedDate = DateTime.Now,
                        EventObjectId = eventObject.Id,
                        Status = "Active",
                        FontColor = model.ParticipantComplete,
                        ImageUrl = MediaHelper.UploadLargeFile(model.ParticipantCompleteImage, "Content/Upload/ParticipantImage")
                    };
                    _unitOfWork.ParticipantImageRepository.Add(participantImage);

                }

                if (model.BroadcastReadyImage != null)
                {
                    var broadcastImage = new BroadcastImage
                    {
                        ActivityStatus = Domain.Common.ActivityStatus.Ready,
                        Id = Guid.NewGuid(),
                        CreatedBy = "1",
                        CreatedDate = DateTime.Now,
                        EventObjectId = eventObject.Id,
                        Status = "Active",
                        FontColor = model.BroadcastReady,
                        ImageUrl = MediaHelper.UploadLargeFile(model.BroadcastReadyImage, "Content/Upload/BroadcastImage")
                    };
                    _unitOfWork.BroadcastImageRepository.Add(broadcastImage);

                }
                if (model.BroadcastActiveImage != null)
                {
                    var broadcastImage = new BroadcastImage
                    {
                        ActivityStatus = Domain.Common.ActivityStatus.Active,
                        Id = Guid.NewGuid(),
                        CreatedBy = "1",
                        CreatedDate = DateTime.Now,
                        EventObjectId = eventObject.Id,
                        Status = "Active",
                        FontColor = model.BroadcastActive,
                        ImageUrl = MediaHelper.UploadLargeFile(model.BroadcastActiveImage, "Content/Upload/BroadcastImage")
                    };
                    _unitOfWork.BroadcastImageRepository.Add(broadcastImage);

                }
                if (model.BroadcastCompleteImage != null)
                {
                    var broadcastImage = new BroadcastImage
                    {
                        ActivityStatus = Domain.Common.ActivityStatus.Complete,
                        Id = Guid.NewGuid(),
                        CreatedBy = "1",
                        CreatedDate = DateTime.Now,
                        EventObjectId = eventObject.Id,
                        Status = "Active",
                        FontColor = model.BroadcastComplete,
                        ImageUrl = MediaHelper.UploadLargeFile(model.ParticipantCompleteImage, "Content/Upload/BroadcastImage")
                    };
                    _unitOfWork.BroadcastImageRepository.Add(broadcastImage);

                }
                await _unitOfWork.CommitAsync();
                return eventObject;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> DeleteEventObject(Guid id)
        {
            try
            {
                var existEventObject = _unitOfWork.EventObjectRepository.Get(a => a.Id == id);
                if (existEventObject == null)
                    return false;
                existEventObject.Status = "Deleted";
                existEventObject.ModifiedDate = DateTime.Now;
                _unitOfWork.EventObjectRepository.Update(existEventObject);
                await _unitOfWork.CommitAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<EventObject>> GetAll()
        {
            return await _unitOfWork.EventObjectRepository.GetAllAsync(a => a.Status == "Active");
        }

        public async Task<EventObject> GetAsync(Guid id)
        {
            return (await _unitOfWork.EventObjectRepository.GetAsync(a => a.Id == id));
        }

        public async Task<bool> UpdateEventObject(Guid id, EventObject model)
        {
            try
            {
                var existEventObject = _unitOfWork.EventObjectRepository.Get(a => a.Id == id);
                if (existEventObject == null)
                    return false;
                existEventObject.ObjectTypeId = model.ObjectTypeId;
                existEventObject.Title = model.Title;
                existEventObject.Description = model.Description;
                existEventObject.Product = model.Product;
                existEventObject.Share = model.Share;
                existEventObject.Scoring = model.Scoring;
                existEventObject.IsActivityTime = model.IsActivityTime;
                existEventObject.IsAverageSpeed = model.IsAverageSpeed;
                existEventObject.ModifiedDate = DateTime.Now;
                _unitOfWork.EventObjectRepository.Update(existEventObject);
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
