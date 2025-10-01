using Data;
using Microsoft.EntityFrameworkCore;

namespace KeycloakApiTemplate.Extensions
{
    public static class AddDatabaseExtensions
    {
        const string ConnectionStringKey = "Default";
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString(ConnectionStringKey);

            return services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(connectionString));
        }
    }
}
