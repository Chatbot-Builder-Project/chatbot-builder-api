using ChatbotBuilderApi.Presentation.Graphs.Metas;

namespace ChatbotBuilderApi.Presentation.Graphs.Links;

public sealed record DataLinkModel(
    InfoMetaModel Info,
    VisualMetaModel Visual,
    int InputPortId,
    int OutputPortId);