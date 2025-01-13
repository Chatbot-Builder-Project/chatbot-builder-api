using ChatbotBuilderApi.Application.Core.Abstract;
using ChatbotBuilderApi.Domain.Graphs.Nodes.ApiAction;
using ChatbotBuilderApi.Domain.Graphs.Nodes.Generation;
using ChatbotBuilderApi.Domain.Graphs.Nodes.Switch.Smart;
using ChatbotBuilderApi.Infrastructure.Files;
using ChatbotBuilderApi.Infrastructure.GraphServices;
using ChatbotBuilderApi.Infrastructure.PipelineBehaviors;
using ChatbotBuilderProtos.V1.Executor;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace ChatbotBuilderApi.DependencyInjection;

public static class InfrastructureServicesExtension
{
    public static void AddInfrastructureServices(
        this IServiceCollection services,
        IWebHostEnvironment env,
        IConfiguration configuration)
    {
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingPipelineBehavior<,>));
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));

        services.AddAuthentication()
            .AddBearerToken(IdentityConstants.BearerScheme);

        services.AddHttpClient<IApiActionService, ApiActionService>();

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

        services.AddGrpcClient<ExecutorService.ExecutorServiceClient>(options =>
        {
            var executorUri = configuration["ExecutorService:Uri"]
                              ?? throw new ArgumentException("ExecutorService:Uri not found");
            options.Address = new Uri(executorUri);
        });

        services.AddScoped<IGenerationService, GenerationService>();
        services.AddScoped<ISmartRoutingService, SmartRoutingService>();
    }
}