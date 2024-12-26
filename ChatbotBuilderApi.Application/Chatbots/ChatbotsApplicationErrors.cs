using ChatbotBuilderApi.Domain.Core.Primitives;

namespace ChatbotBuilderApi.Application.Chatbots;

public static class ChatbotsApplicationErrors
{
    public static readonly Error WorkflowNotFound = Error.NotFound(
        "Chatbots.WorkflowNotFound",
        "Workflow not found.");

    public static readonly Error ChatbotNotFound = Error.NotFound(
        "Chatbots.ChatbotNotFound",
        "Chatbot not found.");
}