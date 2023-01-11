using Domain.Common;
using Domain.Data.Abstracts;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class ParticipantImage : BaseEntity<Guid>
    {
        [ForeignKey("EventObjects")]
        [Description("Relationships with EventObjects")]
        public Guid EventObjectId { get; set; }
        public virtual EventObject EventObjects { get; set; }
        public string ImageUrl { get; set; }
        public string FontColor { get; set; }
        public ActivityStatus ActivityStatus { get; set; }
    }
}
