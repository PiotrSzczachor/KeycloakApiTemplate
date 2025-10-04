namespace Models.DTOs
{
    public sealed record SchoolDto
    (
        Guid Guid,
        string Name,
        Guid AddressGuid
    );
}
