using Models.Domain;

namespace Application.Interfaces
{
    public interface IEventsService
    {
        Task<List<Event>> GetAllEventsAsync();

    }
}
