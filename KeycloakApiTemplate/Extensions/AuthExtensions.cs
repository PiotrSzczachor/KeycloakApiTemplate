namespace KeycloakApiTemplate.Extensions
{
    using Application.Interfaces;
    using Microsoft.AspNetCore.Authentication.Cookies;
    using Microsoft.IdentityModel.Protocols.OpenIdConnect;
    using Microsoft.IdentityModel.Tokens;
    using System.Security.Claims;


    public static class AuthExtensions
    {
        const string Section = "Keycloak";
        public static IServiceCollection AddKeycloakAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var keycloak = configuration.GetSection(Section);

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
            .AddCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                options.Cookie.SameSite = SameSiteMode.Lax;

                options.Events = new CookieAuthenticationEvents
                {
                    OnRedirectToLogin = ctx =>
                    {
                        // Zatrzymujemy cały challenge tutaj
                        ctx.Response.StatusCode = StatusCodes.Status401Unauthorized;
                        return Task.CompletedTask;
                    },
                    OnRedirectToAccessDenied = ctx =>
                    {
                        ctx.Response.StatusCode = StatusCodes.Status403Forbidden;
                        return Task.CompletedTask;
                    }
                };
            })
            .AddOpenIdConnect(options =>
            {
                options.Authority = keycloak["Authority"]!;
                options.ClientId = keycloak["ClientId"]!;
                options.ClientSecret = keycloak["ClientSecret"]!;
                options.ResponseType = OpenIdConnectResponseType.Code;
                options.SaveTokens = true;
                options.RequireHttpsMetadata = false;

                var scope = keycloak["Scope"] ?? "openid profile email offline_access";
                foreach (var s in scope.Split(' ', StringSplitOptions.RemoveEmptyEntries))
                    options.Scope.Add(s);

                options.GetClaimsFromUserInfoEndpoint = true;

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    NameClaimType = "preferred_username",
                    RoleClaimType = ClaimTypes.Role
                };

                options.Events.OnRedirectToIdentityProvider = (context) => {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    return Task.CompletedTask;
                };
                options.Events.OnTokenValidated = async (context) => {
                    // Ta metoda wykonuje sie po każdym zalogowaniu usera
                    // Sprawdzenie czy user o takim keycloak guid już istnieje w bazie
                    // Jeżeli nie to dodanie go do bazy z takim samym guidem jak w keycloaku
                    // Dzieki temu zmapujemy sobie użytkowników z tabelce w bazie na tych keycloakowych
                    var usersService = context.HttpContext.RequestServices
                        .GetRequiredService<IUsersService>();

                    var claims = context.Principal!.Claims;
                    var guid = new Guid(claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value);
                    var name = claims.First(x => x.Type == ClaimTypes.GivenName).Value;
                    var surname = claims.First(x => x.Type == ClaimTypes.Surname).Value;
                    var email = claims.First(x => x.Type == ClaimTypes.Email).Value;

                    await usersService.GetOrCreateAsync(guid, name, surname, email);
                };
            });


            return services;
        }
    }
}
