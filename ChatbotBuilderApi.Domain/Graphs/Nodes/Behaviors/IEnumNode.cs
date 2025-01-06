using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Ids;

namespace ChatbotBuilderApi.Domain.Graphs.Nodes.Behaviors;

/// <summary>
/// A node that might use one or more enums.
/// </summary>
public interface IEnumNode
{
    IEnumerable<EnumId> GetEnumIds();
}