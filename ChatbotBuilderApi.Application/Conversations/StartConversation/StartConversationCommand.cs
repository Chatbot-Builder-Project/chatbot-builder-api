using ChatbotBuilderApi.Application.Core.Abstract.Messaging;
using ChatbotBuilderApi.Domain.Chatbots.ValueObjects;
using ChatbotBuilderApi.Domain.Users;

namespace ChatbotBuilderApi.Application.Conversations.StartConversation;

public sealed class StartConversationCommand : ICommand<StartConversationResponse>
{
    public required ChatbotId ChatbotId { get; init; }
    public required UserId UserId { get; init; }
    public required string Name { get; init; }
}