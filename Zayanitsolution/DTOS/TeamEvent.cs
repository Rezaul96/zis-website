using Domain.Entities;

namespace Scorerecord.DTOS
{
    public class TeamEvent
    {
        public Guid EventId { get; set; }
        public string TeamName { get; set; }
    }
}
