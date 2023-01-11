using Domain.Entities;
using Domain.UnitOfWork;

namespace Scorerecord.Services
{
    public interface ITeamService
    {
        public Task<IEnumerable<Team>> GetAll();
        public Task<IEnumerable<Team>> GetAllTeamByEvent(Guid eventId);
        public Task<IEnumerable<Team>> GetAllEventCode(string eventCode);
        public Task<Team> AddTeam(Team model);
        public Task<bool> UpdateTeam(Guid id, Team model);
        public Task<bool> DeleteTeam(Guid id);
        public Task<Team> GetAsync(Guid accountId);
        public Task<IEnumerable<Team>> GetAllTeamAndTeamMemberByEvent(Guid eventId);
    }
    public class TeamService : ITeamService
    {
        public IUnitOfWork _unitOfWork;
        public TeamService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Team> AddTeam(Team model)
        {
            try
            {
                var team = new Team
                {
                    Id = Guid.NewGuid(),
                    Name = model.Name,
                    EventId = model.EventId,

                    CreatedDate = DateTime.Now,
                    CreatedBy = "1",
                    Status = "Active"
                };
                _unitOfWork.TeamRepository.Add(team);
                await _unitOfWork.CommitAsync();
                return team;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> DeleteTeam(Guid id)
        {
            try
            {
                var existTeam = _unitOfWork.TeamRepository.Get(a => a.Id == id);
                if (existTeam == null)
                    return false;
                existTeam.Status = "Deleted";
                existTeam.ModifiedDate = DateTime.Now;
                _unitOfWork.TeamRepository.Update(existTeam);
                await _unitOfWork.CommitAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<Team>> GetAll()
        {
            return await _unitOfWork.TeamRepository.GetAllAsync(a => a.Status == "Active");
        }
        public async Task<IEnumerable<Team>> GetAllTeamByEvent(Guid eventId)
        {
            return await _unitOfWork.TeamRepository.GetAllAsync(a => a.EventId == eventId && a.Status == "Active");
        }
        public async Task<IEnumerable<Team>> GetAllTeamAndTeamMemberByEvent(Guid eventId)
        {
            var teams = (from rt in await _unitOfWork.TeamRepository.GetAllAsync(a => a.EventId == eventId && a.Status == "Active")
                         let members = _unitOfWork.TeamMemberRepository.GetAll(a => a.TeamId == rt.Id)
                         select new Team
                         {
                             Id = rt.Id,
                             Name = rt.Name,
                             CreatedDate = rt.CreatedDate,
                             EventId = rt.EventId,
                             ModifiedBy = rt.ModifiedBy,
                             ModifiedDate = rt.ModifiedDate,
                             Status = rt.Status,
                             TeamMember = members.Count(),
                             CreatedBy = rt.CreatedBy,
                         });
            return teams;
        }
        public async Task<IEnumerable<Team>> GetAllEventCode(string eventCode)
        {
            var data = await _unitOfWork.TeamRepository.GetAllAsync(a => a.Status == "Active" && a.Events.EventCode == eventCode);
            return data;
        }

        public async Task<Team> GetAsync(Guid id)
        {
            return (await _unitOfWork.TeamRepository.GetAsync(a => a.Id == id));
        }

        public async Task<bool> UpdateTeam(Guid id, Team model)
        {
            try
            {
                var existTeam = _unitOfWork.TeamRepository.Get(a => a.Id == id);
                if (existTeam == null)
                    return false;
                existTeam.EventId = model.EventId;
                existTeam.Name = model.Name;
                existTeam.ModifiedDate = DateTime.Now;
                _unitOfWork.TeamRepository.Update(existTeam);
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
