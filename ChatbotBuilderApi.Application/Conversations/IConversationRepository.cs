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

    Task<Chatbot?> GetChatbotByIdIfAuthorizedAsync(
        ChatbotId chatbotId,
        UserId userId,
        CancellationToken cancellationToken);

    Task<Conversation?> GetByIdAndUserAsync(
        ConversationId conversationId,
        UserId userId,
        CancellationToken cancellationToken);

    Task<PageResponse<ListConversationResponseItem>> ListByQueryAsync(
        ListConversationsQuery query,
        CancellationToken cancellationToken);

    Task<ListMessagesResponse> ListMessagesAsync(
        ConversationId conversationId,
        PageParams pageParams,
        CancellationToken cancellationToken);

    Task<Graph?> GetGraphAsync(
        ConversationId conversationId,
        CancellationToken cancellationToken);

    Task<List<ConversationId>> ListByChatbotIdAsync(
        ChatbotId chatbotId,
        CancellationToken cancellationToken);
}