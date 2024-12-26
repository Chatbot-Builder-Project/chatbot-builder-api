using ChatbotBuilderApi.Application.Core.Abstract.Messaging;
using ChatbotBuilderApi.Domain.Chatbots.ValueObjects;
using ChatbotBuilderApi.Domain.Users;

namespace ChatbotBuilderApi.Application.Chatbots.DeleteChatbot;

public sealed class DeleteChatbotCommand : ICommand
{
    public required ChatbotId Id { get; init; }
    public required UserId OwnerId { get; init; }
}