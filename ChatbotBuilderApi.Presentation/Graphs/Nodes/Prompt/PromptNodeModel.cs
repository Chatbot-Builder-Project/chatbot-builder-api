using ChatbotBuilderApi.Application.Graphs.Nodes;
using ChatbotBuilderApi.Presentation.Graphs.Metas;
using ChatbotBuilderApi.Presentation.Graphs.Ports;

namespace ChatbotBuilderApi.Presentation.Graphs.Nodes.Prompt;

/// <summary>
/// Prompt node model:
/// <list type="bullet">
/// <item>A text template that contains placeholders in the format {{port_id}},
/// which are automatically filled with data from the corresponding input ports when the node is activated.</item>
/// <item>Has a single Text output port,
/// typically connected to a Generation but can be used for any text manipulation related task.</item>
/// <item>The number of input ports should match the number of unique placeholders in the template
/// (the same placeholder can be used multiple times). All ports should be of Text data type.</item>
/// </list>
/// </summary>
/// <param name="Info">Generic information for the node.</param>
/// <param name="Visual">Visual information for the node.</param>
/// <param name="Template">String value containing the template.</param>
/// <param name="OutputPort">Output port of the node. Must be of Text data type.</param>
/// <param name="InputPorts">List of input ports of the node. All must be of Text data type.</param>
public sealed record PromptNodeModel(
    InfoMetaModel Info,
    VisualMetaModel Visual,
    string Template,
    OutputPortModel OutputPort,
    IReadOnlyList<InputPortModel> InputPorts)
    : NodeModel(Info, Visual, NodeType.Prompt);