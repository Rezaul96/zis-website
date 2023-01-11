using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class EventSequenceObject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [ForeignKey("Events")]
        [Description("Relationships with Events")]
        public Guid EventId { get; set; }
        public virtual Event Events { get; set; }

        [ForeignKey("SequenceObjects")]
        [Description("Relationships with SequenceObjects")]
        public Guid SequenceObjectId { get; set; }
        public virtual SequenceObject SequenceObjects { get; set; }

        [ForeignKey("EventObjects")]
        [Description("Relationships with EventObjects")]
        public Guid EventObjectId { get; set; }
        public virtual EventObject EventObjects { get; set; }

        [ForeignKey("Sequences")]
        [Description("Relationships with Sequences")]
        public Guid SequenceId { get; set; }
        public virtual Sequence Sequences { get; set; }
        public int Position { get; set; }
        public ActivityStatus ActivityStatus { get; set; }
        public bool IsLoginEventObject { get; set; }
    }
}
