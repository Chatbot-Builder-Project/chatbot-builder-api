using ChatbotBuilderApi.DependencyInjection;
using ChatbotBuilderApi.Domain.Users;
using ChatbotBuilderApi.WebApplicationExtensions;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddPresentationServices(builder.Configuration);

if (!builder.Environment.IsProduction())
{
    builder.Services.AddSwaggerDocumentation();
}

var app = builder.Build();

if (!app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

await app.MigrateAsync();

app.UseHttpsRedirection();
app.UseCors("AllowedOriginsPolicy");
app.UseSerilogRequestLogging();
app.UseAuthorization();
app.MapControllers();
app.MapGroup("api/v1/users")
    .WithTags("Users")
    .MapIdentityApi<User>();

await app.RunAsync();