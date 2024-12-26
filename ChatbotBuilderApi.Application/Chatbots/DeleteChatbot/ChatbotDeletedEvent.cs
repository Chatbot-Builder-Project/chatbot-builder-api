using ChatbotBuilderApi.Application.Core.Abstract.Messaging;
using ChatbotBuilderApi.Domain.Chatbots.ValueObjects;
using ChatbotBuilderApi.Domain.Users;

namespace ChatbotBuilderApi.Application.Chatbots.DeleteChatbot;

public sealed record ChatbotDeletedEvent(
    ChatbotId ChatbotId,
    UserId OwnerId
) : IEvent;