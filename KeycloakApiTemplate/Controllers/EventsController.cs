using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models.Domain;
using Models.DTOs;

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
        [ProducesResponseType(typeof(EventDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllEvents()
        {
            var offers = await _eventsService.GetAllEventsAsync();
            return Ok();
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


        [HttpPost]
        [ProducesResponseType(typeof(EventDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateEvent([FromBody] Event eventDto)
        {
            if (eventDto == null)
                return BadRequest("Event data is required.");

            var createdEvent = await _eventsService.CreateEventAsync(eventDto);

            return Ok(createdEvent);
        }

        [HttpPut]
        [ProducesResponseType(typeof(EventDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateEventAsync([FromBody] Event eventDto)
        {
            var createdEvent = await _eventsService.UpdateEventAsync(eventDto);
            return Ok();
        }
    }
}
