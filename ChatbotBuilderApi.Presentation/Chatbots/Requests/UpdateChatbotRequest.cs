namespace ChatbotBuilderApi.Presentation.Chatbots.Requests;

public sealed record UpdateChatbotRequest(
    string Name,
    string Description,
    bool IsPublic);