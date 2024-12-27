using ChatbotBuilderApi.Application.Graphs.Nodes;
using ChatbotBuilderApi.Presentation.Graphs.Metas;
using ChatbotBuilderApi.Presentation.Graphs.Ports;

namespace ChatbotBuilderApi.Presentation.Graphs.Nodes;

public sealed record PromptNodeModel(
    InfoMetaModel Info,
    VisualMetaModel Visual,
    string Template,
    InputPortModel InputPort,
    IReadOnlyList<OutputPortModel> OutputPorts)
    : NodeModel(Info, Visual, NodeType.Prompt);