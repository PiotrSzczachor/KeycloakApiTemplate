namespace Models.DTOs
{
    public sealed record ParticipantDto(
        Guid Guid,
        string Name,
        string? Surname,
        string Email,
        string Phone,
        ParticipantEventStatus? EventParticipationStatus
    );
}
