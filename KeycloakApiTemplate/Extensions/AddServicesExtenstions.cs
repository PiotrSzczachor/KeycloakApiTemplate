using Application.Interfaces;
using Application.Services;

namespace KeycloakApiTemplate.Extensions
{
    public static class AddServicesExtenstions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services
                .AddScoped<IUsersService, UsersService>()
                .AddScoped<IEventsService, EventsService>()
            ;
        }
    }
}
