using ChatbotBuilderApi.Domain.Graphs.Abstract;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Ids;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Meta;

namespace ChatbotBuilderApi.Domain.Graphs.Entities.Links;

public sealed class DataLink : Link<DataLinkId>
{
    public InputPortId InputPortId { get; } = null!;
    public OutputPortId OutputPortId { get; } = null!;

    private DataLink(
        DataLinkId id,
        InfoMeta info,
        VisualMeta visual,
        InputPortId inputPortId,
        OutputPortId outputPortId)
        : base(id, info, visual)
    {
        InputPortId = inputPortId;
        OutputPortId = outputPortId;
    }

    /// <inheritdoc/>
    private DataLink()
    {
    }

    public static DataLink Create(
        DataLinkId id,
        InfoMeta info,
        VisualMeta visual,
        InputPortId inputPortId,
        OutputPortId outputPortId)
    {
        return new DataLink(id, info, visual, inputPortId, outputPortId);
    }
}