namespace ChatbotBuilderApi.Presentation.Chatbots.Requests;

public sealed record CreateChatbotRequest(
    Guid WorkflowId,
    bool IsPublic);