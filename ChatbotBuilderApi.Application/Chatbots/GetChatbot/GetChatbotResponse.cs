using ChatbotBuilderApi.Domain.Chatbots.ValueObjects;
using ChatbotBuilderApi.Domain.Users;
using ChatbotBuilderApi.Domain.Workflows;
using Version = ChatbotBuilderApi.Domain.Chatbots.ValueObjects.Version;

namespace ChatbotBuilderApi.Application.Chatbots.GetChatbot;

public sealed record GetChatbotResponse(
    ChatbotId Id,
    UserId OwnerId,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    string Name,
    string Description,
    GetChatbotResponseAdminDetails? AdminDetails);

public sealed record GetChatbotResponseAdminDetails(
    Version Version,
    WorkflowId WorkflowId,
    bool IsPublic,
    bool IsLatest);