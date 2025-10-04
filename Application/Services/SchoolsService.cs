using Application.Extensions;
using Application.Interfaces;
using Data;
using Microsoft.EntityFrameworkCore;
using Models.Domain;
using Models.DTOs;

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

        public async Task<ICollection<StudentDto>> GetStudentsAsync(Guid guid)
        {
            var school = await _dbContext.Schools.Include(s => s.Users).FirstOrDefaultAsync(s => s.Guid == guid);
            var schoolUsers = school?.Users.Select(u => u.ToStudentDto()).ToList();
            return schoolUsers ?? new List<StudentDto>();
        }

    }
}
