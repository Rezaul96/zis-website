using Domain.Common;
using Domain.Data.Abstracts;
using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class EventObject : BaseEntity<Guid>
    {

        [ForeignKey("ObjectTypes")]
        [Description("Relationships with ObjectTypes")]
        public Guid ObjectTypeId { get; set; }
        public virtual ObjectType ObjectTypes { get; set; }
        public Guid? ParentEventObjectId { get; set; }
        public string ObjectName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Product { get; set; }
        public bool Share { get; set; }
        public string Scoring { get; set; }
        public bool IsActivityTime { get; set; }
        public bool IsAverageSpeed { get; set; }
        [NotMapped]
        public ActivityStatus ObjectStatus { get; set; }
        [NotMapped]
        public bool IsLoginEventObject { get; set; }

        [NotMapped]
        public IFormFile BroadcastReadyImage { get; set; }
        [NotMapped]
        public IFormFile BroadcastActiveImage { get; set; }
        [NotMapped]
        public IFormFile BroadcastCompleteImage { get; set; }
        [NotMapped]
        public IFormFile ParticipantActiveImage { get; set; }
        [NotMapped]
        public IFormFile ParticipantReadyImage { get; set; }
        [NotMapped]
        public IFormFile ParticipantCompleteImage { get; set; }
        [NotMapped]
        public Guid[] MemberId { get; set; }

        [NotMapped]
        public string BroadcastReady { get; set; }
        [NotMapped]
        public string BroadcastActive { get; set; }
        [NotMapped]
        public string BroadcastComplete { get; set; }
        [NotMapped]
        public string ParticipantActive { get; set; }
        [NotMapped]
        public string ParticipantReady { get; set; }
        [NotMapped]
        public string ParticipantComplete { get; set; }
        [NotMapped]
        public List<EventObjectDetail> EventObjectDetails { get; set; }

    }
}
