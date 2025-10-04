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

        public async Task<ICollection<SchoolDto>> GetAllAsync()
        {
            return await _dbContext.Schools.Select(s => new SchoolDto(s.Guid, s.Name ?? "", s.AddressGuid ?? Guid.Empty)).ToListAsync();
        }

        public async Task<SchoolDto?> GetAsync(Guid guid)
        {
            return await _dbContext.Schools.Select(o => new SchoolDto(o.Guid, o.Name ?? "", o.AddressGuid ?? Guid.Empty)).FirstOrDefaultAsync(o => o.Guid == guid);
        }

    }
}
