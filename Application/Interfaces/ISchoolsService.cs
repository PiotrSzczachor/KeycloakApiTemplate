namespace Application.Interfaces
{
    public interface ISchoolsService
    {
        Task<Guid> CreateAsync(string name);
    }
}
