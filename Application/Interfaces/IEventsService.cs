using Models.Domain;
using Models.DTOs;

namespace Application.Interfaces
{
    public interface IEventsService
    {
        Task<List<EventDto>> GetAllEventsAsync();
        Task<List<EventDto>> GetOrganizerEventsAsync(Guid organizerId);
        Task<EventDto> CreateEventAsync(Event @event);
        Task<EventDto> UpdateEventAsync(Event @event);
        Task<EventDto> GetEventDetailsAsync(Guid eventId);
        Task<bool> AssignUserToEventAsync(PatchUserStatusEventDto dto);
        Task<bool> UpdateUserStatusAsync(PatchUserStatusEventDto dto);
    }
}
