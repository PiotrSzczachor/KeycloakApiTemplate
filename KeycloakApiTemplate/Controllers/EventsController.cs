using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Auth;
using Models.Domain;
using Models.DTOs;
using System.Security.Claims;

namespace KeycloakApiTemplate.Controllers
{
    [ApiController]
    //[Authorize]
    [Route("events")]
    public class EventsController : Controller
    {
        private readonly IEventsService _eventsService;
        public EventsController(IEventsService eventsService)
        {
            _eventsService = eventsService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ICollection<EventDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllEvents()
        {
            var offers = await _eventsService.GetAllEventsAsync();
            return Ok(offers);
        }

        [HttpGet("organizer/{organizerId:guid}")]
        [ProducesResponseType(typeof(List<EventDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetOrganizerEvents(Guid organizerId)
        {
            var events = await _eventsService.GetOrganizerEventsAsync(organizerId);
            return Ok(events);
        }

        [HttpGet("{eventId:guid}")]
        [ProducesResponseType(typeof(EventDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetEventDetails(Guid eventId)
        {
            var eventDetails = await _eventsService.GetEventDetailsAsync(eventId);

            if (eventDetails is null)
                return NotFound($"Event with ID {eventId} not found.");

            return Ok(eventDetails);
        }

        [Authorize]
        [HttpPost]
        [ProducesResponseType(typeof(EventDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateEvent([FromBody] AddEventDto eventDto)
        {
            if (eventDto == null)
                return BadRequest("Event data is required.");

            var claims = HttpContext.User.Claims;
            var userGuid = claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            var userRole = claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;
            if (userGuid == null || userRole == null || userRole != Roles.Organization)
            {
                return Forbid();
            }

            var createdEvent = await _eventsService.CreateEventAsync(eventDto, new Guid(userGuid));

            return Ok(createdEvent);
        }

        [HttpPut]
        [ProducesResponseType(typeof(EventDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateEventAsync([FromBody] Event eventDto)
        {
            var createdEvent = await _eventsService.UpdateEventAsync(eventDto);
            return Ok();
        }

        [HttpPatch("assign")]
        [ProducesResponseType(typeof(EventDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> AssignUserToEvent([FromBody] PatchUserStatusEventDto dto)
        {
            var success = await _eventsService.AssignUserToEventAsync(dto);

            if (!success)
                return NotFound("Event or User not found.");

            return Ok("User successfully assigned to event.");
        }

        [HttpPatch("{eventId}/status/{status}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> AssignOrUpdateUserStatus([FromBody] PatchUserStatusEventDto dto)
        {
            var success = await _eventsService.UpdateUserStatusAsync(dto);

            if (!success)
                return NotFound("Event or UserEvent not found.");

            return Ok("Status updated successfully.");
        }
    }
}
