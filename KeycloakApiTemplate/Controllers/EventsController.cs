using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Auth;
using Models.Domain;
using Models.DTOs;

namespace KeycloakApiTemplate.Controllers
{
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
            var offers = _eventsService.GetAllEventsAsync();
            return Ok();
        }
    }
}
