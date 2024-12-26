using ChatbotBuilderApi.Domain.Core;
using ChatbotBuilderApi.Domain.Core.Primitives;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Ids;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Meta;

namespace ChatbotBuilderApi.Domain.Graphs.Abstract;

public abstract class Port<TId> : Entity<TId>
    where TId : EntityId<TId>
{
    public InfoMeta Info { get; } = null!;
    public VisualMeta Visual { get; } = null!;
    public NodeId NodeId { get; } = null!;

    protected Port(
        TId id,
        InfoMeta info,
        VisualMeta visual,
        NodeId nodeId)
        : base(id)
    {
        Info = info;
        Visual = visual;
        NodeId = nodeId;
    }

    /// <inheritdoc/>
    protected Port()
    {
    }

    public void EnsureNodeIdIs(NodeId nodeId)
    {
        if (NodeId != nodeId)
        {
            throw new DomainException(GraphsDomainErrors.Port.NodeIdMismatch);
        }
    }
}