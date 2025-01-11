using ChatbotBuilderApi.Application.Graphs.Nodes;
using ChatbotBuilderApi.Presentation.Graphs.Metas;
using ChatbotBuilderApi.Presentation.Graphs.Ports;

namespace ChatbotBuilderApi.Presentation.Graphs.Nodes.Switch;

/// <summary>
/// Smart switch node model:
/// <list type="bullet">
/// <item>Routes the flow dynamically based on a provided text</item>
/// <item>Uses an LLM call behind the hood to predict the next flow link</item>
/// <item>Every option of the enum corresponds to a flow link,
/// so you should provide the enum ID and a map of each option string to its FlowLinkId</item>
/// <item>The input port should be of Text data type</item>
/// </list>
/// </summary>
/// <param name="Info">Generic information for the node.</param>
/// <param name="Visual">Visual information for the node.</param>
/// <param name="InputPort">Input port of the node. Must be of Text data type.</param>
/// <param name="EnumId">ID of the enum to use for the options.</param>
/// <param name="OptionFlowLinkIds">Map of each option value to its FlowLinkId</param>
public sealed record SmartSwitchNodeModel(
    InfoMetaModel Info,
    VisualMetaModel Visual,
    InputPortModel InputPort,
    int EnumId,
    IReadOnlyDictionary<string, int> OptionFlowLinkIds)
    : NodeModel(Info, Visual, NodeType.SmartSwitch);