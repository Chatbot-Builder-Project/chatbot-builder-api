using ChatbotBuilderApi.Domain.Conversations.ValueObjects;
using ChatbotBuilderApi.Domain.Graphs.Traversal;

namespace ChatbotBuilderApi.Domain.Conversations.Flow;

public interface IConversationFlowService
{
    IGraphTraversalService GraphTraversalService { get; }
    Conversation Conversation { get; set; }
    Task InitializeConversationAsync();
    Task ProcessInputMessageAsync(InputMessage inputMessage);
}