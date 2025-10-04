namespace Application.Interfaces
{
    public interface IUsersService
    {
        Task<Guid> GetOrCreateAsync(Guid keycloakId, string name, string surname, string email, string phoneNumber, DateTime dateOfBirth, string role); 
    }
}
