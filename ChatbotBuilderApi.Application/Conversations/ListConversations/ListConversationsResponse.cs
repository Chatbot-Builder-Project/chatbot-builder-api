using ChatbotBuilderApi.Application.Core.Shared.Responses;
using ChatbotBuilderApi.Domain.Chatbots.ValueObjects;
using ChatbotBuilderApi.Domain.Conversations.ValueObjects;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Meta;
using ChatbotBuilderApi.Domain.Users;

namespace ChatbotBuilderApi.Application.Conversations.ListConversations;

public sealed record ListConversationsResponse(PageResponse<ListConversationResponseItem> Page);

public sealed record ListConversationResponseItem(
    ConversationId Id,
    UserId OwnerId,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    string Name,
    ChatbotId ChatbotId,
    VisualMeta Visual);