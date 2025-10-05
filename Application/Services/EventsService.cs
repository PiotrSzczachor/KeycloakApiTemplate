using Application.Extensions;
using Application.Interfaces;
using Data;
using Microsoft.EntityFrameworkCore;
using Models.Domain;
using Models.DTOs;

namespace Application.Services
{
    public sealed class EventsService : IEventsService
    {
        private readonly AppDbContext _context;
        private readonly IAddressesService _addressesService;
        public EventsService(AppDbContext context, IAddressesService addressesService)
        {
            _context = context;
            _addressesService = addressesService;
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
        public async Task<ICollection<EventDto>> GetAllUserEventsAsync(Guid userId)
        {
            var userEventsGuids = _context.UsersEvents.Where(x => x.UserGuid == userId).Select(x => x.EventGuid);
            var events = await _context.Events.Where(x => !x.Closed && userEventsGuids.Contains(x.Guid))
                .Include(e => e.Address)
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

        public async Task<Guid> CreateEventAsync(AddEventDto addEventDto, Guid userId)
        {
            var organization = _context.Organizations.Where(x => x.UserGuid == userId).FirstOrDefault();
            if(organization  == null)
            {
                throw new InvalidDataException();
            }
            var address = new Address { City = addEventDto.AddressCity, BuildingNumber = addEventDto.AddressBuildingNumber, PostalCode = addEventDto.AddressPostalCode ?? "", Street = addEventDto.AddressStreet };
            var addressGuid = await _addressesService.CreateAddressAsync(address);
            var utcStart = DateTime.SpecifyKind(addEventDto.StartDate ?? new DateTime(), DateTimeKind.Utc);
            var utcEnd = DateTime.SpecifyKind(addEventDto.StartDate ?? new DateTime(), DateTimeKind.Utc);
            var newEvent = new Event { OrganizationGuid = organization.Guid, AddressGuid = addressGuid, StartDate = utcStart, EndDate = utcEnd, Description = addEventDto.Description, Title = addEventDto.Title };
            _context.Events.Add(newEvent);
            await _context.SaveChangesAsync();
            return newEvent.Guid;
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

        public async Task<bool> AssignUserToEventAsync(PatchUserStatusEventDto dto)
        {
            var ev = await _context.Events
                .Include(e => e.UserEvents)
                .FirstOrDefaultAsync(e => e.Guid == dto.EventId && !e.Closed);

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Guid == dto.UserId);

            if (ev == null || user == null)
                return false;

            var userEvent = ev.UserEvents.FirstOrDefault(ue => ue.UserGuid == dto.UserId);
            if (userEvent != null)
            {
                userEvent.ParticipantEventStatus = dto.ParticipantEventStatus;
            }
            else
            {
                userEvent = new UserEvent
                {
                    UserGuid = dto.UserId,
                    EventGuid = dto.EventId,
                    ParticipantEventStatus = dto.ParticipantEventStatus
                };
                _context.UsersEvents.Add(userEvent);
            }

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateUserStatusAsync(PatchUserStatusEventDto dto)
        {
            var userEvent = await _context.UsersEvents
                .FirstOrDefaultAsync(ue => ue.EventGuid == dto.EventId && ue.UserGuid == dto.UserId);

            if (userEvent == null)
                return false;

            userEvent.ParticipantEventStatus = dto.ParticipantEventStatus;

            await _context.SaveChangesAsync();
            return true;
        }


    }
}
