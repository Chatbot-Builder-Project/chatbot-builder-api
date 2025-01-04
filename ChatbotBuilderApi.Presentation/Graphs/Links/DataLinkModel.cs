using ChatbotBuilderApi.Presentation.Graphs.Metas;

namespace ChatbotBuilderApi.Presentation.Graphs.Links;

/// <summary>
/// Data link between two ports.
/// </summary>
/// <param name="Info">Generic information for the link.</param>
/// <param name="Visual">Visual information for the link.</param>
/// <param name="SourcePortId">ID of the source port. Which must be an OutputPort.</param>
/// <param name="TargetPortId">ID of the target port. Which must be an InputPort.</param>
public sealed record DataLinkModel(
    InfoMetaModel Info,
    VisualMetaModel Visual,
    int SourcePortId,
    int TargetPortId);