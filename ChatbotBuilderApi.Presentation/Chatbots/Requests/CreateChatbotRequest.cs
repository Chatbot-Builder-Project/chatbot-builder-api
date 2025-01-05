namespace ChatbotBuilderApi.Presentation.Chatbots.Requests;

/// <summary>
/// Request to create a chatbot.
/// </summary>
/// <param name="WorkflowId">ID of the workflow the chatbot is part of.</param>
/// <param name="IsPublic">Whether the chatbot is publicly available.</param>
public sealed record CreateChatbotRequest(
    Guid WorkflowId,
    bool IsPublic);