using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
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
        public async Task<IActionResult> GetAllOffers()
        {
            var offers = await _eventsService.GetAllEventsAsync();
            return Ok();
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
