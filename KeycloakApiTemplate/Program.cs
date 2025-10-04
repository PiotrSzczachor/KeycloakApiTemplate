using KeycloakApiTemplate.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Models.Profiles;

const string CorsPolicyName = "AllowSwaggerAndFrontend";

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddServices();
builder.Services.AddKeycloakAuthentication(builder.Configuration);
builder.Services.AddDatabase(configuration);
builder.Services.AddHttpClient("oidc");
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<UserMappingProfile>();
    cfg.AddProfile<EventMappingProfile>();
});

builder.Services.AddCors(CorsPolicyName);





var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1");
    });
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseCors(CorsPolicyName);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
