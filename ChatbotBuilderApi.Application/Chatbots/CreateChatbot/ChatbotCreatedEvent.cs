using ChatbotBuilderApi.Application.Core.Abstract.Messaging;
using ChatbotBuilderApi.Domain.Chatbots.ValueObjects;

namespace ChatbotBuilderApi.Application.Chatbots.CreateChatbot;

public sealed record ChatbotCreatedEvent(ChatbotId Id) : IEvent;