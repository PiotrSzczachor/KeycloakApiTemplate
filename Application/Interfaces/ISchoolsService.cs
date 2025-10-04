using Models.DTOs;

namespace Application.Interfaces
{
    public interface ISchoolsService
    {
        Task<Guid> CreateAsync(string name);
        Task<ICollection<StudentDto>> GetStudentsAsync(Guid id);
        Task<ICollection<StudentDto>> GetAsync(Guid id);
        Task<ICollection<StudentDto>> GetAllAsync();
    }
}
