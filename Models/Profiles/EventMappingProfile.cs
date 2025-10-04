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
                .ForMember(dest => dest.OrganizationName, opt => opt.MapFrom(src => src.Organization.User.Name))
                .ForMember(dest => dest.AddressCity, opt => opt.MapFrom(src => src.Address.City))
                .ForMember(dest => dest.AddressStreet, opt => opt.MapFrom(src => src.Address.Street))
                .ForMember(dest => dest.Participants, opt => opt.MapFrom(src => src.UserEvents.Select(ue => ue.User)));

        }
    }
}