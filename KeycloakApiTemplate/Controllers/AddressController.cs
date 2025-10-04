using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KeycloakApiTemplate.Controllers
{
    public class AddressController : Controller
    {
        private readonly IEventsService _eventsService;
        public AddressController(IEventsService eventsService)
        {
            _eventsService = eventsService;
        }
    }
}
