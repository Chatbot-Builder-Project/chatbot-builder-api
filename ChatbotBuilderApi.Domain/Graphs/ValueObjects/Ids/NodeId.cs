using ChatbotBuilderApi.Domain.Core.Primitives;

namespace ChatbotBuilderApi.Domain.Graphs.ValueObjects.Ids;

public sealed class NodeId : EntityId<NodeId>
{
    public NodeId(Guid value) : base(value)
    {
    }
}