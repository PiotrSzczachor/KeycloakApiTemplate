namespace Models.DTOs
{
    public sealed record EventDto(
       Guid Guid,
       Guid? OrganizationGuid,
       string? OrganizationName,
       string? Title,
       string? Description,
       DateTime? StartDate,
       DateTime? EndDate,
       Guid? AddressGuid,
       string? AddressCity,
       string? AddressFlatNumber,
       string? AddressBuildingNumber,
       string? PostalCode,
       string? AddressStreet,
       string? Qualifications,
       bool Closed,
       List<ParticipantDto> Participants = null
   );
}
