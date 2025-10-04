using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs;

namespace KeycloakApiTemplate.Controllers
{
    [ApiController]
    //[Authorize]
    [Route("schools")]
    public class SchoolsController : Controller
    {
        private readonly ISchoolsService _schoolsService;
        public SchoolsController(ISchoolsService schoolsService)
        {
            _schoolsService = schoolsService;
        }

        [HttpGet("{id}/students", Name = "GetSchoolStudents")]
        [ProducesResponseType(typeof(ICollection<StudentDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetSchoolStudents(Guid id)
        {
            var result = await _schoolsService.GetStudentsAsync(id);
            return Ok(result);
        }

        [HttpGet("", Name = "GetAllSchools")]
        [ProducesResponseType(typeof(ICollection<SchoolDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetSchools()
        {
            var result = await _schoolsService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}/event", Name = "GetSchool")]
        [ProducesResponseType(typeof(SchoolDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetOrganizationEvents(Guid id)
        {
            var result = await _schoolsService.GetAsync(id);
            return Ok(result);
        }
    }
}
