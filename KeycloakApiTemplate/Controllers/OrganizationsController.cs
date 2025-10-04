using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Auth;
using Models.DTOs;
using System.Security.Claims;

namespace KeycloakApiTemplate.Controllers
{
    [ApiController]
    //[Authorize]
    [Route("organizations")]
    public class OrganizationsController : Controller
    {
        private readonly IOrganizationsService _organizationsService;
        public OrganizationsController(IOrganizationsService organizationsService)
        {
            _organizationsService = organizationsService;
        }

        [HttpGet("", Name = "GetAllOrganizations")]
        [ProducesResponseType(typeof(ICollection<OrganizationDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetOrganizations()
        {
            var result = await _organizationsService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}", Name = "GetOrganization")]
        [ProducesResponseType(typeof(OrganizationDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetOrganization(Guid id)
        {
            var result = await _organizationsService.GetAsync(id);
            return Ok(result);
        }

        [HttpGet("{id}/event", Name = "GetOrganizationEvents")]
        [ProducesResponseType(typeof(ICollection<EventDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetOrganizationEvents(Guid id)
        {
            var result = await _organizationsService.GetEventsAsync(id);
            return Ok(result);
        }
    }
}
