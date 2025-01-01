using ChatbotBuilderApi.Application.Chatbots;
using ChatbotBuilderApi.Application.Conversations;
using ChatbotBuilderApi.Application.Core.Abstract;
using ChatbotBuilderApi.Application.Images;
using ChatbotBuilderApi.Application.Workflows;
using ChatbotBuilderApi.Domain.Users;
using ChatbotBuilderApi.Persistence;
using ChatbotBuilderApi.Persistence.Repositories;
using ChatbotBuilderApi.Persistence.Repositories.Images;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ChatbotBuilderApi.DependencyInjection;

public static class PersistenceServicesExtension
{
    public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            options.UseSqlServer(configuration.GetConnectionString("AppDbContextConnection") ??
                                 throw new ArgumentException("AppDbContextConnection not found"));
        });

        services.AddIdentityCore<User>()
            .AddRoles<Role>()
            .AddEntityFrameworkStores<AppDbContext>()
            .AddApiEndpoints()
            .AddDefaultTokenProviders();

        services.AddMediatR(config =>
            config.RegisterServicesFromAssembly(AssemblyReference.Assembly));

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IChatbotRepository, ChatbotRepository>();
        services.AddScoped<IConversationRepository, ConversationRepository>();
        services.AddScoped<IWorkflowRepository, WorkflowRepository>();
        services.AddScoped<IImageRepository, ImageRepository>();

        services.AddScoped<ImageCudRepository>();
        services.AddScoped<IImageCudRepository>(p => p.GetRequiredService<ImageCudRepository>());
        services.AddScopedTransactionHandler(p => p.GetRequiredService<ImageCudRepository>());
    }
}