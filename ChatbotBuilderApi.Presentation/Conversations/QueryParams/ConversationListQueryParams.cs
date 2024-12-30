using ChatbotBuilderApi.Application.Core.Shared;

namespace ChatbotBuilderApi.Presentation.Conversations.QueryParams;

public sealed record ConversationListQueryParams(
    PageParams PageParams,
    string? Search,
    Guid? ChatbotId);