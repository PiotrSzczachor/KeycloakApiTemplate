using Application.Interfaces;
using Data;
using Microsoft.EntityFrameworkCore;
using Models.Domain;

namespace Application.Services
{
    sealed class EventsService : IEventsService
    {
        private readonly AppDbContext _context;
        public EventsService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Event>> GetAllEventsAsync()
        {
            return await _context.Events
                .Include(e => e.Address)
                .Include(e => e.UserEvents)
                    .ThenInclude(ue => ue.User)
                .ToListAsync();
        }


    }
}
