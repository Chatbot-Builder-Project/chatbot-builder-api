using ChatbotBuilderApi.Presentation.Conversations.Messages.ViewModels;

namespace ChatbotBuilderApi.Presentation.Conversations.ViewModels;

/// <summary>
/// View model for starting a conversation.
/// </summary>
/// <param name="ConversationId">ID of the conversation.</param>
/// <param name="InitialMessage">Initial message of the conversation.</param>
public sealed record StartConversationViewModel(
    Guid ConversationId,
    OutputMessageViewModel InitialMessage);