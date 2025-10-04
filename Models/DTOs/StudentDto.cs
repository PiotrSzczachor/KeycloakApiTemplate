namespace Models.DTOs
{
    public sealed record StudentDto(
        Guid Guid,
        string Name,
        string? Surname,
        string Email,
        string Phone,
        Guid SchoolGuid
    );
}
