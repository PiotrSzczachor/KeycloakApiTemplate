using Models.Domain;
using Models.DTOs;

namespace Application.Interfaces
{
    public interface IEventsService
    {
        Task<List<EventDto>> GetAllEventsAsync();
        Task<EventDto> CreateEventAsync(Event @event);
        Task<EventDto> UpdateEventAsync(Event @event);
    }
}
