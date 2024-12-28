using ChatbotBuilderApi.Domain.Graphs.Abstract;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Ids;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Meta;

namespace ChatbotBuilderApi.Domain.Graphs.Entities.Links;

public sealed class FlowLink : Link<FlowLinkId>
{
    public NodeId SourceNodeId { get; } = null!;
    public NodeId TargetNodeId { get; } = null!;

    private FlowLink(
        FlowLinkId id,
        InfoMeta info,
        VisualMeta visual,
        NodeId sourceNodeId,
        NodeId targetNodeId)
        : base(id, info, visual)
    {
        SourceNodeId = sourceNodeId;
        TargetNodeId = targetNodeId;
    }

    /// <inheritdoc/>
    private FlowLink()
    {
    }

    public static FlowLink Create(
        FlowLinkId id,
        InfoMeta info,
        VisualMeta visual,
        NodeId sourceNodeId,
        NodeId targetNodeId)
    {
        return new FlowLink(id, info, visual, sourceNodeId, targetNodeId);
    }
}