using ChatbotBuilderApi.Infrastructure.PipelineBehaviors;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace ChatbotBuilderApi.DependencyInjection;

public static class InfrastructureServicesExtension
{
    public static void AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingPipelineBehavior<,>));
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));

        services.AddAuthentication()
            .AddBearerToken(IdentityConstants.BearerScheme);
    }
}