using ChatbotBuilderApi.Application.Graphs.Nodes;
using ChatbotBuilderApi.Presentation.Graphs.Data;
using ChatbotBuilderApi.Presentation.Graphs.Metas;
using ChatbotBuilderApi.Presentation.Graphs.Ports;

namespace ChatbotBuilderApi.Presentation.Graphs.Nodes.Static;

public sealed record StaticNodeModel(
    InfoMetaModel Info,
    VisualMetaModel Visual,
    DataModel Data,
    OutputPortModel OutputPort)
    : NodeModel(Info, Visual, NodeType.Static);