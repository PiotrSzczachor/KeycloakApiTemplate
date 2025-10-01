using Application.Interfaces;
using Data;
using Microsoft.EntityFrameworkCore;
using Models.Domain;

namespace Application.Services
{
    public sealed class UsersService : IUsersService
    {
        private readonly AppDbContext _dbContext;
        public UsersService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> GetOrCreateAsync(Guid keycloakId, string name, string surname, string email)
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
                Email = email
            };

            _dbContext.Users.Add(newUser);
            await _dbContext.SaveChangesAsync();

            return newUser.Guid;
        }
    }
}
