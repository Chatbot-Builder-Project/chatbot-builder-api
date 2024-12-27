using ChatbotBuilderApi.Application.Graphs.Nodes;
using ChatbotBuilderApi.Presentation.Graphs.Data;
using ChatbotBuilderApi.Presentation.Graphs.Metas;
using ChatbotBuilderApi.Presentation.Graphs.Ports;

namespace ChatbotBuilderApi.Presentation.Graphs.Nodes;

public sealed record SwitchNodeModel(
    InfoMetaModel Info,
    VisualMetaModel Visual,
    InputPortModel InputPort,
    int EnumId,
    IReadOnlyDictionary<OptionDataModel, int> FlowLinkIds)
    : NodeModel(Info, Visual, NodeType.Switch);