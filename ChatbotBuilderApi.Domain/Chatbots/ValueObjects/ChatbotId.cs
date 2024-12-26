using ChatbotBuilderApi.Domain.Core.Primitives;

namespace ChatbotBuilderApi.Domain.Chatbots.ValueObjects;

public sealed class ChatbotId : EntityId<ChatbotId>
{
    public ChatbotId(Guid value) : base(value)
    {
    }
}