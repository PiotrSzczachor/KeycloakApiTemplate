using Application.Interfaces;
using Data;
using Models.Domain;

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
    }
}
