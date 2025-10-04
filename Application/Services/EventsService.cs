using Application.Extensions;
using Application.Interfaces;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models.Domain;
using Models.DTOs;

namespace Application.Services
{
    public sealed class EventsService : IEventsService
    {
        private readonly AppDbContext _context;
        public EventsService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<EventDto>> GetAllEventsAsync()
        {
            var events = await _context.Events.Where(x => !x.Closed)
                .Include(e => e.Address)
                .Include(e => e.Organization).ThenInclude(o => o.User)
                .Include(e => e.UserEvents).ThenInclude(ue => ue.User)
                .ToListAsync();

            return events.Select(e => e.ToDto()).ToList();
        }
        public async Task<List<EventDto>> GetOrganizerEventsAsync(Guid organizerId)
        {
            var events = await _context.Events.Where(x => !x.Closed)
                .Include(e => e.Address)
                .Include(e => e.Organization).ThenInclude(o => o.User)
                .Include(e => e.UserEvents).ThenInclude(ue => ue.User)
                .Where(x => x.OrganizationGuid == organizerId)
                .ToListAsync();

            return events.Select(e => e.ToDto()).ToList();
        }

        public async Task<EventDto> GetEventDetailsAsync(Guid eventId)
        { 
            var ev = await _context.Events
                .Include(e => e.Address)
                .Include(e => e.Organization).ThenInclude(o => o.User)
                .Include(e => e.UserEvents).ThenInclude(ue => ue.User)
                .FirstOrDefaultAsync(x => x.Guid == eventId && !x.Closed);

            if (ev is null)
                return null;

            return ev.ToDto();
        }

        public async Task<EventDto> CreateEventAsync(Event @event)
        {
            _context.Events.Add(@event);
            await _context.SaveChangesAsync();
            return @event.ToDto();
        }

        public async Task<EventDto> UpdateEventAsync(Event @event)
        {
            var existing = await _context.Events
                .FirstOrDefaultAsync(e => e.Guid == @event.Guid);

            if (existing is null)
                throw new KeyNotFoundException($"Event with Guid '{@event.Guid}' not found.");

            existing.StartDate = @event.StartDate;
            existing.EndDate = @event.EndDate;
            existing.Qualifications = @event.Qualifications;
            existing.Closed = @event.Closed;

            existing.AddressGuid = @event.AddressGuid;
            existing.OrganizationGuid = @event.OrganizationGuid;

            await _context.SaveChangesAsync();

            return @event.ToDto();
        }


    }
}
