namespace Models.DTOs
{
    public sealed record AddEventDto
    (
        string? Title,
        string? Description,
        DateTime? StartDate,
        DateTime? EndDate,
        string? AddressCity,
        string? AddressBuildingNumber,
        string? AddressPostalCode,
        string? AddressStreet
    );
}
