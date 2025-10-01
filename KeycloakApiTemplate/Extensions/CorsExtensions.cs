namespace KeycloakApiTemplate.Extensions
{
    public static class CorsExtensions
    {
        public static IServiceCollection AddCors(this IServiceCollection services, string corsPolicyName)
        {
            return services.AddCors(options =>
            {
                options.AddPolicy(corsPolicyName, policy =>
                {
                    policy.WithOrigins(
                            "https://localhost:7186", // Swagger
                            "http://localhost:4200"   // Frontend url
                        )
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                });
            });
        }
    }
}
