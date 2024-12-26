using ChatbotBuilderApi.Domain.Graphs.Abstract;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Ids;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Meta;

namespace ChatbotBuilderApi.Domain.Graphs.Entities.Links;

public sealed class FlowLink : Link<FlowLinkId>
{
    public NodeId InputNodeId { get; } = null!;
    public NodeId OutputNodeId { get; } = null!;

    private FlowLink(
        FlowLinkId id,
        InfoMeta info,
        VisualMeta visual,
        NodeId inputNodeId,
        NodeId outputNodeId)
        : base(id, info, visual)
    {
        InputNodeId = inputNodeId;
        OutputNodeId = outputNodeId;
    }

    /// <inheritdoc/>
    private FlowLink()
    {
    }

    public static FlowLink Create(
        FlowLinkId id,
        InfoMeta info,
        VisualMeta visual,
        NodeId inputNodeId,
        NodeId outputNodeId)
    {
        return new FlowLink(id, info, visual, inputNodeId, outputNodeId);
    }
}