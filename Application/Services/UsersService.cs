using Application.Interfaces;
using Data;
using Microsoft.EntityFrameworkCore;
using Models.Auth;
using Models.Domain;

namespace Application.Services
{
    public sealed class UsersService : IUsersService
    {
        private readonly AppDbContext _dbContext;
        private readonly ISchoolsService _schoolsService;
        private readonly IOrganizationsService _organizationsService;
        public UsersService(AppDbContext dbContext, ISchoolsService schoolsService, IOrganizationsService organizationsService)
        {
            _dbContext = dbContext;
            _schoolsService = schoolsService;
            _organizationsService = organizationsService;
        }

        public async Task<Guid> GetOrCreateAsync(Guid keycloakId, string name, string surname, string email, string phoneNumber, DateTime dateOfBirth, string role)
        {
            using var transaction = await _dbContext.Database.BeginTransactionAsync();

            try
            {
                var user = await _dbContext.Users
                    .AsNoTracking()
                    .FirstOrDefaultAsync(u => u.Guid == keycloakId);

                if (user != null)
                    return user.Guid;

                var newUser = new User
                {
                    Guid = keycloakId,
                    Name = name,
                    Surname = surname,
                    Email = email,
                    Phone = phoneNumber,
                    DateOfBirth = dateOfBirth,
                    Role = role
                };

                switch (role)
                {
                    case Roles.Coordinator:
                        {
                            var schoolGuid = await _schoolsService.CreateAsync(name);
                            newUser.SchoolGuid = schoolGuid;
                            break;
                        }
                    case Roles.Organization:
                        {
                            var organizationGuid = await _organizationsService.CreateAsync(name);
                            newUser.OrganizationGuid = organizationGuid;
                            break;
                        }
                }

                _dbContext.Users.Add(newUser);
                await _dbContext.SaveChangesAsync();

                await transaction.CommitAsync();
                return newUser.Guid;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}
