using ChatbotBuilderApi.Application.Core.Abstract.Messaging;
using ChatbotBuilderApi.Application.Core.Shared.Responses;
using ChatbotBuilderApi.Domain.Chatbots.ValueObjects;
using ChatbotBuilderApi.Domain.Users;
using ChatbotBuilderApi.Domain.Workflows;

namespace ChatbotBuilderApi.Application.Chatbots.CreateChatbot;

public sealed class CreateChatbotCommand : ICommand<CreateResponse<ChatbotId>>
{
    public required WorkflowId WorkflowId { get; init; }
    public required UserId OwnerId { get; init; }
    public required bool IsPublic { get; init; }
}