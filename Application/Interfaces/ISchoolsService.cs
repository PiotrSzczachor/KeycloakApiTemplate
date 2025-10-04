using Models.DTOs;

namespace Application.Interfaces
{
    public interface ISchoolsService
    {
        Task<Guid> CreateAsync(string name);
        Task<ICollection<ParticipantDto>> GetStudentsAsync();
    }
}
