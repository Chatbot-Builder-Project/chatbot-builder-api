using ChatbotBuilderApi.Application.Graphs.Nodes;
using ChatbotBuilderApi.Presentation.Graphs.Metas;
using ChatbotBuilderApi.Presentation.Graphs.Ports;

namespace ChatbotBuilderApi.Presentation.Graphs.Nodes.Switch;

/// <summary>
/// Switch node model:
/// <list type="bullet">
/// <item>Routes the flow based on a provided option</item>
/// <item>Every option of the enum corresponds to a flow link,
/// so you should provide the enum ID and a map of each option string to its FlowLinkId</item>
/// <item>The input port should be of Option data type</item>
/// </list>
/// </summary>
/// <param name="Info">Generic information for the node.</param>
/// <param name="Visual">Visual information for the node.</param>
/// <param name="InputPort">Input port of the node. Must be of Option data type.</param>
/// <param name="EnumId">ID of the enum to use for the options.</param>
/// <param name="OptionFlowLinkIds">Map of each option value to its FlowLinkId</param>
public sealed record SwitchNodeModel(
    InfoMetaModel Info,
    VisualMetaModel Visual,
    InputPortModel InputPort,
    int EnumId,
    IReadOnlyDictionary<string, int> OptionFlowLinkIds)
    : NodeModel(Info, Visual, NodeType.Switch);