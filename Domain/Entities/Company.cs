using Domain.Data.Abstracts;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Company : BaseEntity<Guid>
    {
        [ForeignKey("Regions")]
        [Description("Relationships with Regions")]
        public Guid RegionId { get; set; }
        public virtual Region Regions { get; set; }

        [ForeignKey("Industries")]
        [Description("Relationships with Industries")]
        public Guid IndustryId { get; set; }
        public virtual Industry Industries { get; set; }

        public string Name { get; set; }
        public string AboutUs { get; set; }
        public string Logo { get; set; }
    }
}
