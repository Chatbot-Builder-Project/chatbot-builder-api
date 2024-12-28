using ChatbotBuilderApi.Domain.Graphs.Abstract;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Ids;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Meta;

namespace ChatbotBuilderApi.Domain.Graphs.Entities.Links;

public sealed class DataLink : Link<DataLinkId>
{
    public InputPortId TargetPortId { get; } = null!;
    public OutputPortId SourcePortId { get; } = null!;

    private DataLink(
        DataLinkId id,
        InfoMeta info,
        VisualMeta visual,
        InputPortId targetPortId,
        OutputPortId sourcePortId)
        : base(id, info, visual)
    {
        TargetPortId = targetPortId;
        SourcePortId = sourcePortId;
    }

    /// <inheritdoc/>
    private DataLink()
    {
    }

    public static DataLink Create(
        DataLinkId id,
        InfoMeta info,
        VisualMeta visual,
        InputPortId targetPortId,
        OutputPortId sourcePortId)
    {
        return new DataLink(id, info, visual, targetPortId, sourcePortId);
    }
}