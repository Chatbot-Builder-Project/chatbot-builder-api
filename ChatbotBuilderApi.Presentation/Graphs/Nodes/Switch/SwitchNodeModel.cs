using ChatbotBuilderApi.Application.Graphs.Nodes;
using ChatbotBuilderApi.Presentation.Graphs.Metas;
using ChatbotBuilderApi.Presentation.Graphs.Ports;

namespace ChatbotBuilderApi.Presentation.Graphs.Nodes.Switch;

/// <param name="Info"></param>
/// <param name="Visual"></param>
/// <param name="InputPort"></param>
/// <param name="EnumId"></param>
/// <param name="OptionFlowLinkIds">Map of each option string to its FlowLinkId</param>
public sealed record SwitchNodeModel(
    InfoMetaModel Info,
    VisualMetaModel Visual,
    InputPortModel InputPort,
    int EnumId,
    IReadOnlyDictionary<string, int> OptionFlowLinkIds)
    : NodeModel(Info, Visual, NodeType.Switch);