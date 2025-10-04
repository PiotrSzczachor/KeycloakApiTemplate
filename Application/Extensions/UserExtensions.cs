using Models.Domain;
using Models.DTOs;

namespace Application.Extensions
{
    public static class UserExtensions
    {
        public static StudentDto ToStudentDto(this User user)
        {
            return new StudentDto(user.Guid, user.Name, user.Surname, user.Email, user.Phone, user.SchoolGuid ?? Guid.Empty);
        }
    }
}
