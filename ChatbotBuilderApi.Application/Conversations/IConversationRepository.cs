using ChatbotBuilderApi.Application.Conversations.ListConversations;
using ChatbotBuilderApi.Application.Conversations.ListMessages;
using ChatbotBuilderApi.Application.Core.Shared;
using ChatbotBuilderApi.Application.Core.Shared.Responses;
using ChatbotBuilderApi.Domain.Chatbots;
using ChatbotBuilderApi.Domain.Chatbots.ValueObjects;
using ChatbotBuilderApi.Domain.Conversations;
using ChatbotBuilderApi.Domain.Conversations.ValueObjects;
using ChatbotBuilderApi.Domain.Graphs;
using ChatbotBuilderApi.Domain.Users;

namespace ChatbotBuilderApi.Application.Conversations;

public interface IConversationRepository
{
    void Add(Conversation conversation, Graph conversationGraph);
    void Update(Conversation conversation);
    void Delete(Conversation conversation);

    /// <remarks>
    /// Includes the chatbot graph.
    /// </remarks>
    Task<Chatbot?> GetChatbotByIdIfAuthorizedAsync(
        ChatbotId chatbotId,
        UserId userId,
        CancellationToken cancellationToken);

    /// <remarks>
    /// Does not include messages.
    /// </remarks>
    Task<Conversation?> GetByIdAndUserAsync(
        ConversationId conversationId,
        UserId userId,
        CancellationToken cancellationToken);

    /// <remarks>
    /// Use when you want to include and track all changes and new messages.
    /// </remarks>
    Task<Conversation?> LoadByIdAndUserAsync(
        ConversationId conversationId,
        UserId userId,
        CancellationToken cancellationToken);

    /// <remarks>
    /// Loads and tracks the graph for the conversation.
    /// Use only when you want to update the conversation with new messages.
    /// </remarks>
    Task<Graph?> LoadGraphAsync(
        ConversationId conversationId,
        CancellationToken cancellationToken);

    Task<PageResponse<ListConversationResponseItem>> ListByQueryAsync(
        ListConversationsQuery query,
        CancellationToken cancellationToken);

    Task<ListMessagesResponse> ListMessagesAsync(
        ConversationId conversationId,
        PageParams pageParams,
        CancellationToken cancellationToken);

    Task<List<ConversationId>> ListByChatbotIdAsync(
        ChatbotId chatbotId,
        CancellationToken cancellationToken);
}