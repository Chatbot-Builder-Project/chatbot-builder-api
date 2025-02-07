using ChatbotBuilderApi.DependencyInjection;
using ChatbotBuilderApi.Presentation.Users.Extensions;
using ChatbotBuilderApi.WebApplicationExtensions;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

builder.Services.AddDomainServices();
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Environment, builder.Configuration);
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

app.Use(async (context, next) =>
{
    using var cts = new CancellationTokenSource(TimeSpan.FromMinutes(5));
    context.RequestAborted = cts.Token;
    await next();
});
app.UseHttpsRedirection();
app.UseCors("AllowedOriginsPolicy");
app.UseSerilogRequestLogging();
app.UseAuthorization();
app.MapControllers();
app.MapIdentityEndpoints();

await app.RunAsync();