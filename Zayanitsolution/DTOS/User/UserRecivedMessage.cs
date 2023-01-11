using Domain.Common;

namespace Scorerecord.DTOS.User
{
    public class UserRecivedMessage
    {
        public string ObjectName { get; set; }
        public string ObjectTitle { get; set; }
        public string ParticipantImage { get; set; }
        public string ObjectSequenceStatus { get; set; }
    }
}
