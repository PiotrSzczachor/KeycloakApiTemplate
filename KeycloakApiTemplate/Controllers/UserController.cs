using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Auth;
using System.Security.Claims;

namespace KeycloakApiTemplate.Controllers
{
    [ApiController]
    [Authorize]
    [Route("user")]
    public class UserController : Controller
    {
        [HttpGet("info")]
        public IActionResult Me()
        {
            var guid = User.Claims
                .First(c => c.Type == ClaimTypes.NameIdentifier).Value;

            var roles = User.Claims
                .Where(c => c.Type == ClaimTypes.Role)
                .Select(c => c.Value)
                .ToList();

            var claims = User.Claims
                .Where(c => c.Type == "claims")
                .Select(c => c.Value)
                .ToList();

            var email = User.Claims
                .First(c => c.Type == ClaimTypes.Email).Value;

            var name = User.Claims
                .First(c => c.Type == ClaimTypes.GivenName).Value;

            var surname = User.Claims
                .First(c => c.Type == ClaimTypes.Surname).Value;

            return Ok(new AuthInfo(true, new Guid(guid), roles, claims, name, surname, email));
        }
    }
}
