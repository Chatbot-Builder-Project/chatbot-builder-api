using ChatbotBuilderApi.Presentation.Conversations.Messages.ViewModels;

namespace ChatbotBuilderApi.Presentation.Conversations.ViewModels;

public sealed record StartConversationViewModel(
    Guid ConversationId,
    OutputMessageViewModel InitialMessage);