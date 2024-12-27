namespace ChatbotBuilderApi.Presentation.Conversations.Requests;

public sealed record StartConversationRequest(
    Guid ChatbotId,
    string Name);