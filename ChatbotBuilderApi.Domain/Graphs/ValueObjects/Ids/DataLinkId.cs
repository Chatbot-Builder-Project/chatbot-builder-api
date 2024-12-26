using ChatbotBuilderApi.Domain.Core.Primitives;

namespace ChatbotBuilderApi.Domain.Graphs.ValueObjects.Ids;

public sealed class DataLinkId : EntityId<DataLinkId>
{
    public DataLinkId(Guid value) : base(value)
    {
    }
}