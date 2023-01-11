using Domain.Data.Abstracts;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;


namespace Domain.Entities
{
    public class EventScorerecord : BaseEntity<Guid>
    {
        [ForeignKey("EventObjectDetails")]
        [Description("Relationships with EventObjectDetails")]
        public Guid EventObjectDetailId { get; set; }
        public virtual EventObjectDetail EventObjectDetails { get; set; }

        [ForeignKey("TeamMembers")]
        [Description("Relationships with TeamMembers")]
        public Guid TeamMemberId { get; set; }
        public virtual TeamMember TeamMembers { get; set; }
        public int Point { get; set; }
        public string Comment { get; set; }
        public TimeSpan CountTime { get; set; }
    }
}
