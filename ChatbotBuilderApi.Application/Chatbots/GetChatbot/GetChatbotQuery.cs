using ChatbotBuilderApi.Application.Core.Abstract.Messaging;
using ChatbotBuilderApi.Domain.Chatbots.ValueObjects;
using ChatbotBuilderApi.Domain.Users;

namespace ChatbotBuilderApi.Application.Chatbots.GetChatbot;

public sealed class GetChatbotQuery : IQuery<GetChatbotResponse>
{
    public required ChatbotId Id { get; init; }
    public required UserId UserId { get; init; }
    public required bool IncludeGraphForAdmin { get; init; }
}