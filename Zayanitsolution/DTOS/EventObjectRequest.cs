using Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Scorerecord.DTOS
{
    public class EventObjectRequest
    {
      
        public EventObject EventObject { get; set; }
        public Guid[] MemberId { get; set; }
        public BroadcastImage BroadcastReadyImage { get; set; }
        public BroadcastImage BroadcastActiveImage { get; set; }
        public BroadcastImage BroadcastCompleteImage { get; set; }
        public ParticipantImage ParticipantActiveImage { get; set; }
        public ParticipantImage ParticipantReadyImage { get; set; }
        public ParticipantImage ParticipantCompleteImage { get; set; }
    }
}
