using Domain.Common;
using Domain.Data.Abstracts;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Domain.Entities
{
    public class SequenceObject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [ForeignKey("EventObjects")]
        [Description("Relationships with EventObjects")]
        public Guid EventObjectId { get; set; }
        public virtual EventObject EventObjects { get; set; }

        [ForeignKey("Sequences")]
        [Description("Relationships with Sequences")]
        public Guid SequenceId { get; set; }
        public virtual Sequence Sequences { get; set; }
        public int Position { get; set; }
        public bool IsLoginEventObject { get; set; }


    }
}
