using ChatbotBuilderApi.Application.Graphs.Nodes;
using ChatbotBuilderApi.Presentation.Graphs.Metas;
using ChatbotBuilderApi.Presentation.Graphs.Ports;

namespace ChatbotBuilderApi.Presentation.Graphs.Nodes.Prompt;

public sealed record PromptNodeModel(
    InfoMetaModel Info,
    VisualMetaModel Visual,
    string Template,
    OutputPortModel OutputPort,
    IReadOnlyList<InputPortModel> InputPorts)
    : NodeModel(Info, Visual, NodeType.Prompt);