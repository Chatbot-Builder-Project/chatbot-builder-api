using ChatbotBuilderApi.Application.Chatbots.DeleteChatbot;
using ChatbotBuilderApi.Application.Conversations.DeleteConversation;
using ChatbotBuilderApi.Application.Core.Abstract;
using ChatbotBuilderApi.Application.Core.Abstract.Messaging;
using ChatbotBuilderApi.Application.Workflows.DeleteWorkflow;
using ChatbotBuilderApi.Application.Workflows.UpdateWorkflow;
using ChatbotBuilderApi.Domain.Chatbots;
using ChatbotBuilderApi.Domain.Conversations;
using ChatbotBuilderApi.Domain.Graphs;
using ChatbotBuilderApi.Domain.Workflows;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ChatbotBuilderApi.Persistence.Repositories.EventHandlers;

public sealed class GraphCleanupEventHandler :
    IEventHandler<WorkflowUpdatedEvent>,
    IEventHandler<WorkflowDeletedEvent>,
    IEventHandler<ChatbotDeletedEvent>,
    IEventHandler<ConversationDeletedEvent>
{
    private readonly AppDbContext _context;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<GraphCleanupEventHandler> _logger;

    public GraphCleanupEventHandler(
        AppDbContext context,
        IUnitOfWork unitOfWork,
        ILogger<GraphCleanupEventHandler> logger)
    {
        _context = context;
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    private async Task DeleteDetachedGraphsAsync(CancellationToken cancellationToken)
    {
        // Delete graphs that are not associated with any workflow, chatbot or conversation
        await _context.Set<Graph>()
            .Where(g =>
                !_context.Set<Workflow>().Any(w => w.Graph.Id == g.Id) &&
                !_context.Set<Chatbot>().Any(c => c.Graph.Id == g.Id) &&
                !_context.Set<Conversation>().Any(c => c.GraphId == g.Id))
            .ExecuteDeleteAsync(cancellationToken);

        await _unitOfWork.CommitAsync(cancellationToken);
    }

    public async Task Handle(WorkflowUpdatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Cleaning up detached graphs after {nameof(WorkflowUpdatedEvent)}");
        await DeleteDetachedGraphsAsync(cancellationToken);
    }

    public async Task Handle(WorkflowDeletedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Cleaning up detached graphs after {nameof(WorkflowDeletedEvent)}");
        await DeleteDetachedGraphsAsync(cancellationToken);
    }

    public async Task Handle(ChatbotDeletedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Cleaning up detached graphs after {nameof(ChatbotDeletedEvent)}");
        await DeleteDetachedGraphsAsync(cancellationToken);
    }

    public async Task Handle(ConversationDeletedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Cleaning up detached graphs after {nameof(ConversationDeletedEvent)}");
        await DeleteDetachedGraphsAsync(cancellationToken);
    }
}