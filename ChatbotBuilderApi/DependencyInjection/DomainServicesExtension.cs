using ChatbotBuilderApi.Domain.Conversations;
using ChatbotBuilderApi.Domain.Conversations.Abstract;
using ChatbotBuilderApi.Domain.Graphs;
using ChatbotBuilderApi.Domain.Graphs.Abstract;

namespace ChatbotBuilderApi.DependencyInjection;

public static class DomainServicesExtension
{
    public static void AddDomainServices(this IServiceCollection services)
    {
        services.AddMediatR(config =>
            config.RegisterServicesFromAssembly(Domain.AssemblyReference.Assembly));

        services.AddTransient<IGraphTraversalService, GraphTraversalService>();
        services.AddTransient<IConversationFlowService, ConversationFlowService>();
    }
}