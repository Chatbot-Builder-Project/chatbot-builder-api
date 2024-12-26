using ChatbotBuilderApi.Application.Core.Abstract.Messaging;
using ChatbotBuilderApi.Domain.Conversations.ValueObjects;
using ChatbotBuilderApi.Domain.Users;

namespace ChatbotBuilderApi.Application.Conversations.DeleteConversation;

public sealed class DeleteConversationCommand : ICommand
{
    public required ConversationId Id { get; init; }
    public required UserId OwnerId { get; init; }
}