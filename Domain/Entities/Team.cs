using Domain.Data.Abstracts;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Team : BaseEntity<Guid>
    {
        [ForeignKey("Events")]
        [Description("Relationships with Events")]
        public Guid EventId { get; set; }
        public virtual Event Events { get; set; }
        public string Name { get; set; }
        [NotMapped]
        public int TeamMember { get; set; }

    }
}
