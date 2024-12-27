using ChatbotBuilderApi.Application.Graphs.Shared.Data;
using ChatbotBuilderApi.Presentation.Graphs.Metas;

namespace ChatbotBuilderApi.Presentation.Graphs.Ports;

public sealed record OutputPortModel(
    InfoMetaModel Info,
    VisualMetaModel Visual,
    int NodeId,
    DataType DataType);