using Application.Extensions;
using Application.Interfaces;
using Data;
using Microsoft.EntityFrameworkCore;
using Models.Domain;
using Models.DTOs;

namespace Application.Services
{
    public class OrganizationsService : IOrganizationsService
    {
        private readonly AppDbContext _dbContext;
        public OrganizationsService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Guid> CreateAsync(string name)
        {
            var newOrganization = new Organization
            {
                Name = name,
            };

            _dbContext.Organizations.Add(newOrganization);
            await _dbContext.SaveChangesAsync();

            return newOrganization.Guid;
        }

        public async Task<ICollection<OrganizationDto>> GetAllAsync()
        {
            return await _dbContext.Organizations.Select(o => new OrganizationDto(o.Guid, o.Name ?? "", o.AddressGuid)).ToListAsync();
        }

        public async Task<OrganizationDto?> GetAsync(Guid guid)
        {
            return await _dbContext.Organizations.Select(o => new OrganizationDto(o.Guid, o.Name ?? "", o.AddressGuid)).FirstOrDefaultAsync(o => o.Guid == guid);
        }

        public async Task<ICollection<EventDto>> GetEventsAsync(Guid organizationGuid)
        {
            var organization = await _dbContext.Organizations.FirstOrDefaultAsync(o => o.Guid == organizationGuid);
            return organization?.Events.Select(e => e.ToDto()).ToList() ?? new List<EventDto>();
        }
    }
}
