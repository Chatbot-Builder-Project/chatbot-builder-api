using ChatbotBuilderApi.Application.Core.Shared.Responses;

namespace ChatbotBuilderApi.Presentation.Conversations.Messages.ViewModels;

public sealed record MessageListViewModel(
    PageResponse<InputMessageViewModel> InputMessagesPage,
    PageResponse<OutputMessageViewModel> OutputMessagesPage);