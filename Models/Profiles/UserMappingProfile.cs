using AutoMapper;
using Models.Domain;
using Models.DTOs;

namespace Models.Profiles
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, ParticipantDto>();
        }
    }
}
