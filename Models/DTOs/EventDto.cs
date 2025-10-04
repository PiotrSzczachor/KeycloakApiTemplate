namespace Models.DTOs
{
    public sealed record EventDto(
        Guid Guid,
        Guid OrganizationGuid,
        string OrganizationName,
        DateTime? StartDate,
        DateTime? EndDate,
        Guid AddressGuid,
        string AddressCity,
        string AddressStreet,
        string? Qualifications,
        bool Closed,
        List<ParticipantDto> Participants
    );
}
