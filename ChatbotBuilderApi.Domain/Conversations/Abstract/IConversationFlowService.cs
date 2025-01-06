using ChatbotBuilderApi.Domain.Conversations.ValueObjects;
using ChatbotBuilderApi.Domain.Graphs.Abstract.Services;

namespace ChatbotBuilderApi.Domain.Conversations.Abstract;

public interface IConversationFlowService
{
    IGraphTraversalService GraphTraversalService { get; }
    Conversation Conversation { get; set; }
    Task InitializeConversationAsync();
    Task ProcessInputMessageAsync(InputMessage inputMessage);
}