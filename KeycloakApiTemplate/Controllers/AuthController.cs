using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Mvc;

namespace KeycloakApiTemplate.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : Controller
    {
        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        [HttpGet("login", Name = "Login")]
        public IActionResult Login(string? returnUrl = "/")
        {
            return Challenge(new AuthenticationProperties { RedirectUri = returnUrl }, OpenIdConnectDefaults.AuthenticationScheme);
        }


        [HttpGet("logout", Name = "Logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);


            var keycloak = _configuration.GetSection("Keycloak");
            var idToken = await HttpContext.GetTokenAsync("id_token");
            var keycloakAuthority = keycloak["Authority"]!.TrimEnd('/');
            var clientId = keycloak["ClientId"];


            var endSessionUrl = $"{keycloakAuthority}/protocol/openid-connect/logout?client_id={Uri.EscapeDataString(clientId)}";
            if (!string.IsNullOrEmpty(idToken))
                endSessionUrl += $"&id_token_hint={Uri.EscapeDataString(idToken)}";


            return Redirect(endSessionUrl);
        }
    }
}
