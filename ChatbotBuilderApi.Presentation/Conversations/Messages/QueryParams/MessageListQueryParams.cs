using ChatbotBuilderApi.Application.Core.Shared;

namespace ChatbotBuilderApi.Presentation.Conversations.Messages.QueryParams;

/// <summary>
/// Query parameters for listing messages in a conversation.
/// </summary>
/// <param name="PageParams">Page parameters for the list of messages.</param>
public sealed record MessageListQueryParams(PageParams PageParams);