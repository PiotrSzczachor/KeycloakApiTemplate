using AutoMapper;
using Models.Domain;
using Models.DTOs;

namespace Models.Profiles
{
    public class EventMappingProfile : Profile
    {
        public EventMappingProfile()
        {
            CreateMap<Event, EventDto>()
                .ForMember(dest => dest.OrganizationName, opt => opt.MapFrom(src => src.Organization != null ? src.Organization.User.Name : string.Empty))
                .ForMember(dest => dest.AddressCity, opt => opt.MapFrom(src => src.Address != null ? src.Address.City : string.Empty))
                .ForMember(dest => dest.AddressStreet, opt => opt.MapFrom(src => src.Address != null ? src.Address.Street : string.Empty))
                .ForMember(dest => dest.Participants, opt => opt.MapFrom(src => src.UserEvents.Select(ue => ue.User)));

        }
    }
}