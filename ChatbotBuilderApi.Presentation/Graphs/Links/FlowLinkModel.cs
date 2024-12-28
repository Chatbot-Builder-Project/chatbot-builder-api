using ChatbotBuilderApi.Presentation.Graphs.Metas;

namespace ChatbotBuilderApi.Presentation.Graphs.Links;

public sealed record FlowLinkModel(
    InfoMetaModel Info,
    VisualMetaModel Visual,
    int SourceNodeId,
    int TargetNodeId);