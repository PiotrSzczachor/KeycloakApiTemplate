using KeycloakApiTemplate.Extensions;

const string CorsPolicyName = "AllowSwaggerAndFrontend";

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddServices();
builder.Services.AddKeycloakAuthentication(builder.Configuration);
builder.Services.AddDatabase(configuration);
builder.Services.AddHttpClient("oidc");
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddCors(CorsPolicyName);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "OpenAPI v1");
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
