using ChatbotBuilderApi.Application.Core.Shared;
using ChatbotBuilderApi.Domain.Chatbots.ValueObjects;

namespace ChatbotBuilderApi.Presentation.Conversations.QueryParams;

public sealed record ConversationListQueryParams(
    PageParams PageParams,
    string? Search,
    ChatbotId? ChatbotId);