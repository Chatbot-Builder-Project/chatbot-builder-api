using ChatbotBuilderApi.Domain.Core.Primitives;

namespace ChatbotBuilderApi.Domain.Graphs.ValueObjects.Ids;

public sealed class FlowLinkId : EntityId<FlowLinkId>
{
    public FlowLinkId(Guid value) : base(value)
    {
    }
}