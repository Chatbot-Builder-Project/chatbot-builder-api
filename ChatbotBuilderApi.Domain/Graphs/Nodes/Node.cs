using ChatbotBuilderApi.Domain.Core.Primitives;
using ChatbotBuilderApi.Domain.Graphs.Traversal;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Ids;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Meta;

namespace ChatbotBuilderApi.Domain.Graphs.Nodes;

public abstract class Node : Entity<NodeId>
{
    public InfoMeta Info { get; } = null!;
    public VisualMeta Visual { get; } = null!;

    protected Node(
        NodeId id,
        InfoMeta info,
        VisualMeta visual)
        : base(id)
    {
        Info = info;
        Visual = visual;
    }

    /// <inheritdoc/>
    protected Node()
    {
    }

    /// <summary>
    /// Any action that need to be executed before all other tasks should be implemented here.
    /// </summary>
    /// <remarks>
    /// The graph will call this method before publishing outputs, or getting the successor node, etc.
    /// </remarks>
    public virtual Task RunAsync(NodeExecutionContext context) => Task.CompletedTask;
}