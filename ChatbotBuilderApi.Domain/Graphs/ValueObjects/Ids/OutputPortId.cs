using ChatbotBuilderApi.Domain.Core.Primitives;

namespace ChatbotBuilderApi.Domain.Graphs.ValueObjects.Ids;

public sealed class OutputPortId : EntityId<OutputPortId>
{
    public OutputPortId(Guid value) : base(value)
    {
    }
}