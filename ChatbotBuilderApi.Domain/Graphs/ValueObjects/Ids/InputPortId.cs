using ChatbotBuilderApi.Domain.Core.Primitives;

namespace ChatbotBuilderApi.Domain.Graphs.ValueObjects.Ids;

public sealed class InputPortId : EntityId<InputPortId>
{
    public InputPortId(Guid value) : base(value)
    {
    }
}