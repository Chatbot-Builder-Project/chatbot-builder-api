using ChatbotBuilderApi.Domain.Core.Primitives;

namespace ChatbotBuilderApi.Domain.Conversations.ValueObjects;

public sealed class ConversationId : EntityId<ConversationId>
{
    public ConversationId(Guid value) : base(value)
    {
    }
}