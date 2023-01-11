using Domain.Entities;

namespace Scorerecord.DTOS.User
{
    public class UserEventResponse
    {
        public UserEventResponse()
        {
            this.TeamMember = new TeamMember();
            this.Event = new Event();
            this.Team = new Team();
        }
        public Event Event { get; set; }
        public Team Team { get; set; }
        public TeamMember TeamMember { get; set; }
    }
}
