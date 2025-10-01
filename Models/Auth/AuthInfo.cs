namespace Models.Auth
{
    public sealed record AuthInfo(
        bool IsAuthenticated,
        Guid Guid,
        IEnumerable<string> Roles, 
        IEnumerable<string> Claims,
        string Name,
        string Surname,
        string Email
    );
}
