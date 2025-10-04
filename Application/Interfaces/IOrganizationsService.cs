using Models.DTOs;

namespace Application.Interfaces
{
    public interface IOrganizationsService
    {
        Task<Guid> CreateAsync(string name);
        Task<OrganizationDto?> GetAsync(Guid guid);
        Task<ICollection<OrganizationDto>> GetAllAsync();
        Task<ICollection<EventDto>> GetEventsAsync(Guid organizationGuid);
    }
}
