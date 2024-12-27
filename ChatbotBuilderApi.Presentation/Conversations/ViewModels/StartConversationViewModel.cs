using ChatbotBuilderApi.Domain.Conversations.ValueObjects;

namespace ChatbotBuilderApi.Presentation.Conversations.ViewModels;

public sealed record StartConversationViewModel(
    Guid ConversationId,
    OutputMessage InitialMessage);