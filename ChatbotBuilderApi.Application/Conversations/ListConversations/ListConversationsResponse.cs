using ChatbotBuilderApi.Application.Core.Shared.Responses;
using ChatbotBuilderApi.Domain.Chatbots.ValueObjects;
using ChatbotBuilderApi.Domain.Conversations.ValueObjects;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Meta;

namespace ChatbotBuilderApi.Application.Conversations.ListConversations;

public sealed record ListConversationsResponse(PageResponse<ListConversationResponseItem> Page);

public sealed record ListConversationResponseItem(
    ConversationId Id,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    string Name,
    ChatbotId ChatbotId,
    VisualMeta Visual);