using Application.Interfaces;
using Data;
using Microsoft.EntityFrameworkCore;
using Models.Domain;
using System.Xml.Linq;

namespace Application.Services
{
    public class SchoolsService : ISchoolsService
    {
        private readonly AppDbContext _dbContext;
        public SchoolsService(AppDbContext dbContext) 
        {
            _dbContext = dbContext;
        }
        public async Task<Guid> CreateAsync(string name)
        {
            var newSchool = new School
            {
                Name = name,
            };

            _dbContext.Schools.Add(newSchool);
            await _dbContext.SaveChangesAsync();

            return newSchool.Guid;
        }
    }
}
