using Domain.Entities;
using Domain.UnitOfWork;

namespace Scorerecord.Services
{
    public interface ISequenceService
    {
        public Task<IEnumerable<Sequence>> GetAll();
        public Task<Sequence> AddSequence(Sequence model);
        public Task<bool> UpdateSequence(Guid id, Sequence model);
        public Task<bool> DeleteSequence(Guid id);
        public Task<Sequence> GetAsync(Guid accountId);
    }
    public class SequenceService : ISequenceService
    {
        public IUnitOfWork _unitOfWork;
        public SequenceService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Sequence> AddSequence(Sequence model)
        {
            try
            {
                var sequence = new Sequence
                {
                    Id = Guid.NewGuid(),
                    Name = model.Name,
                    Description = model.Description,
                    CreatedDate = DateTime.Now,
                    CreatedBy = "1",
                    Status = "Active"
                };
                _unitOfWork.SequenceRepository.Add(sequence);
                await _unitOfWork.CommitAsync();
                return sequence;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> DeleteSequence(Guid id)
        {
            try
            {
                var existSequence = _unitOfWork.SequenceRepository.Get(a => a.Id == id);
                if (existSequence == null)
                    return false;
                existSequence.Status = "Deleted";
                existSequence.ModifiedDate = DateTime.Now;
                _unitOfWork.SequenceRepository.Update(existSequence);
                await _unitOfWork.CommitAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<Sequence>> GetAll()
        {
            return await _unitOfWork.SequenceRepository.GetAllAsync(a => a.Status == "Active");
        }

        public async Task<Sequence> GetAsync(Guid id)
        {
            return (await _unitOfWork.SequenceRepository.GetAsync(a => a.Id == id));
        }

        public async Task<bool> UpdateSequence(Guid id, Sequence model)
        {
            try
            {
                var existSequence = _unitOfWork.SequenceRepository.Get(a => a.Id == id);
                if (existSequence == null)
                    return false;
                existSequence.Description = model.Description;
                existSequence.Name = model.Name;
                existSequence.ModifiedDate = DateTime.Now;
                _unitOfWork.SequenceRepository.Update(existSequence);
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
