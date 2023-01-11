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
    public class EventShare
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [ForeignKey("EventObjects")]
        [Description("Relationships with EventObjects")]
        public Guid EventObjectId { get; set; }
        public virtual EventObject EventObjects { get; set; }

        [ForeignKey("Members")]
        [Description("Relationships with Members")]
        public Guid MemberId { get; set; }
        public virtual Member Members { get; set; }
    }
}
