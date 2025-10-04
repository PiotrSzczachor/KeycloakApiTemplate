namespace Models.DTOs
{
    public sealed record OrganizationDto
    (
        Guid Guid,
        string OrganizationName,
        Guid? AddressGuid
    );
}
