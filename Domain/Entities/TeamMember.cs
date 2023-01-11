using Domain.Data.Abstracts;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class TeamMember : BaseEntity<Guid>
    {
        [ForeignKey("Teams")]
        [Description("Relationships with Teams")]
        public Guid TeamId { get; set; }
        public virtual Team Teams { get; set; }

        public string Email { get; set; }
        public string Name { get; set; }
    }
}
