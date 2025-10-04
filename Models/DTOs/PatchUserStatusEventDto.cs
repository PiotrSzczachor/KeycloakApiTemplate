namespace Models.DTOs
{
    public class PatchUserStatusEventDto
    {
        public Guid EventId { get; set; }
        public Guid UserId { get; set; }
        public ParticipantEventStatus ParticipantEventStatus { get; set; }
    }
}
