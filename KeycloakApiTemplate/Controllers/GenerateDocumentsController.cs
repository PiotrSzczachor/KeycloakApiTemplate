using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models.Domain;
using Models.DTOs;

namespace KeycloakApiTemplate.Controllers
{
    [ApiController]
    //[Authorize]
    [Route("generate")]
    public class GenerateDocumentsController : Controller
    {
        private readonly IGenerateDocumentsService _certificationService;
        private readonly IUsersService _usersService;
        private readonly IEventsService _eventsService;
        public GenerateDocumentsController(IGenerateDocumentsService certificationService, IUsersService usersService, IEventsService eventService)
        {
            _eventsService = eventService;
            _usersService = usersService;
            _certificationService = certificationService;
        }

        [HttpGet("certificate")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCertification([FromQuery] Guid eventId, [FromQuery] Guid userId)
        {
            var @event = await _eventsService.GetEventDetailsAsync(eventId);
            var user = @event.Participants.FirstOrDefault(x => x.Guid == userId);
            if(user.EventParticipationStatus != ParticipantEventStatus.Completed)
            {
                return NoContent();
            }

            var certificateHtml = _certificationService.GenerateCertificateHtml(user, @event);
            return Ok(certificateHtml);
        }

    }
}
