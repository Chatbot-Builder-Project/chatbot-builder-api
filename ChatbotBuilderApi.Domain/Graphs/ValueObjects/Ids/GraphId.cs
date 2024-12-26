using ChatbotBuilderApi.Domain.Core.Primitives;

namespace ChatbotBuilderApi.Domain.Graphs.ValueObjects.Ids;

public sealed class GraphId : EntityId<GraphId>
{
    public GraphId(Guid value) : base(value)
    {
    }
}