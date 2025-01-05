using ChatbotBuilderApi.Application.Core.Shared.Responses;

namespace ChatbotBuilderApi.Presentation.Conversations.Messages.ViewModels;

/// <summary>
/// View model for a list of messages in a conversation.
/// </summary>
/// <param name="InputMessagesPage">Page of input messages.</param>
/// <param name="OutputMessagesPage">Page of output messages.</param>
public sealed record MessageListViewModel(
    PageResponse<InputMessageViewModel> InputMessagesPage,
    PageResponse<OutputMessageViewModel> OutputMessagesPage);