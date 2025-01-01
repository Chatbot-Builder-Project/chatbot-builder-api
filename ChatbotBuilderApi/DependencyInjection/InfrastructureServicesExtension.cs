using ChatbotBuilderApi.Application.Core.Abstract;
using ChatbotBuilderApi.Infrastructure.Files;
using ChatbotBuilderApi.Infrastructure.PipelineBehaviors;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace ChatbotBuilderApi.DependencyInjection;

public static class InfrastructureServicesExtension
{
    public static void AddInfrastructureServices(this IServiceCollection services, IWebHostEnvironment env)
    {
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingPipelineBehavior<,>));
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));

        services.AddAuthentication()
            .AddBearerToken(IdentityConstants.BearerScheme);

        if (env.IsDevelopment())
        {
            services.AddScoped<IFileService>(_ =>
            {
                var storageRoot = Path.Combine(env.ContentRootPath, "files");
                return new LocalFileService(storageRoot);
            });
        }
        else
        {
            services.AddOptions<AzureBlobStorageSettings>()
                .BindConfiguration("AzureBlobStorageSettings");
            services.AddScoped<IFileService, AzureFileService>();
        }
    }
}