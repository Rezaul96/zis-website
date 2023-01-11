using Domain.Entities;

namespace Scorerecord.DTOS.Facilitator
{
    public class FacilitatorEventResponse
    {
        public FacilitatorEventResponse()
        {
            this.LoginEventSequenceObject = new EventSequenceObject();
            this.Event = new Event();
            this.EventObjects = new List<EventObject>();
            this.Teams=new List<Team>();
        }
        public Event Event { get; set; }
        public List<EventObject> EventObjects { get; set; }
        public List<Team> Teams { get; set; }
        public EventSequenceObject LoginEventSequenceObject { get; set; }

    }
}
