using ChatbotBuilderApi.Application.Core.Abstract.Messaging;
using ChatbotBuilderApi.Domain.Conversations.ValueObjects;
using ChatbotBuilderApi.Domain.Users;

namespace ChatbotBuilderApi.Application.Conversations.SendMessage;

public sealed class SendMessageCommand : ICommand<SendMessageResponse>
{
    public required ConversationId ConversationId { get; init; }
    public required UserId UserId { get; init; }
    public required InputMessage InputMessage { get; init; }
}