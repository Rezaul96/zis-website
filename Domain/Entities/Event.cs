using Domain.Common;
using Domain.Data.Abstracts;
using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Event : BaseEntity<Guid>
    {
        [ForeignKey("Companies")]
        [Description("Relationships with Companies")]
        public Guid CompanyId { get; set; }
        public virtual Company Companies { get; set; }
        [ForeignKey("Sequences")]
        [Description("Relationships with Sequences")]
        public Guid SequenceId { get; set; }
        public virtual Sequence Sequences { get; set; }


        [ForeignKey("Members")]
        [Description("Relationships with Members")]
        public Guid MemberId { get; set; }
        public virtual Member Members { get; set; }

        public string QrCode { get; set; }
        public string Name { get; set; }
        public string EventCode { get; set; }
        public DateTime EventDate { get; set; }
        public string Description { get; set; }
        public string CustomRedirectUrl { get; set; }
        public string Icon { get; set; }
        public string HoldingScreanImage { get; set; }
        public EventStatus EventStatus { get; set; }


    }
}
