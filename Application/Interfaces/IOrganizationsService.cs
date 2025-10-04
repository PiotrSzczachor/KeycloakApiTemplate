namespace Application.Interfaces
{
    public interface IOrganizationsService
    {
        Task<Guid> CreateAsync(string name);
    }
}
