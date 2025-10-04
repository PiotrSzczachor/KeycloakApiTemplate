using Models.Domain;
using Models.DTOs;

namespace Application.Extensions
{
    public static class EventExtensions
    {
        public static EventDto ToDto(this Event e)
        {
            var participants = e.UserEvents?
                .Select(ue => new ParticipantDto(
                    Guid: ue.User.Guid,
                    Name: ue.User.Name,
                    Surname: ue.User.Surname,
                    Email: ue.User.Email,
                    Phone: ue.User.Phone
                ))
                .ToList() ?? new List<ParticipantDto>();

            return new EventDto(
                Guid: e.Guid,
                OrganizationGuid: e.OrganizationGuid,
                OrganizationName: e.Organization?.User?.Name,
                StartDate: e.StartDate,
                EndDate: e.EndDate,
                AddressGuid: e.AddressGuid,
                AddressCity: e.Address?.City,
                AddressStreet: e.Address?.Street,
                Qualifications: e.Qualifications,
                Closed: e.Closed
            );
        }
    }
}
