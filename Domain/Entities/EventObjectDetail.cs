using Domain.Data.Abstracts;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Domain.Entities
{
    public class EventObjectDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [ForeignKey("EventObjects")]
        [Description("Relationships with EventObjects")]
        public Guid EventObjectId { get; set; }
        public virtual EventObject EventObjects { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

    }
}
