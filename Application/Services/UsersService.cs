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
                {
                    if(!user.IsAdult)
                    {
                        if (IsAdult(user.DateOfBirth))
                        {
                            user.IsAdult = true;
                            _dbContext.Users.Update(user);
                            await transaction.CommitAsync();
                        }
                    }
                    return user.Guid;
                }
                    

                var newUser = new User
                {
                    Guid = keycloakId,
                    Name = name,
                    Surname = surname,
                    Email = email,
                    Phone = phoneNumber,
                    DateOfBirth = dateOfBirth,
                    Role = role,
                    IsAdult = IsAdult(dateOfBirth)
                };

                Guid organizationId = Guid.Empty;

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
                            organizationId = await _organizationsService.CreateAsync(name);
                            newUser.OrganizationGuid = organizationId;
                            break;
                        }
                }

                _dbContext.Users.Add(newUser);
                await _dbContext.SaveChangesAsync();

                if(role == Roles.Organization)
                {
                    await _organizationsService.AssignUserAsync(organizationId, keycloakId);
                }

                await transaction.CommitAsync();
                return newUser.Guid;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        private static bool IsAdult(DateTime dateOfBirth)
        {
            // Get today's date
            DateTime today = DateTime.Today;

            // Calculate age
            int age = today.Year - dateOfBirth.Year;

            // Adjust if the birthday hasn't occurred yet this year
            if (dateOfBirth.Date > today.AddYears(-age))
            {
                age--;
            }

            // Adult if age is 18 or older
            return age >= 18;
        }
    }
}
