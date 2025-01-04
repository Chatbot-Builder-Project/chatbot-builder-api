using ChatbotBuilderApi.Presentation.Graphs.Metas;

namespace ChatbotBuilderApi.Presentation.Graphs.Links;

/// <summary>
/// Flow link between two nodes.
/// </summary>
/// <param name="Info">Generic information for the link.</param>
/// <param name="Visual">Visual information for the link.</param>
/// <param name="SourceNodeId">ID of the source node. Must be an `Active` node.</param>
/// <param name="TargetNodeId">ID of the target node. Must be an `Active` node.</param>
public sealed record FlowLinkModel(
    InfoMetaModel Info,
    VisualMetaModel Visual,
    int SourceNodeId,
    int TargetNodeId);