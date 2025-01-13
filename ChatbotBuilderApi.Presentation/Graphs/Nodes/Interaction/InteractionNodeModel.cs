using ChatbotBuilderApi.Application.Graphs.Nodes;
using ChatbotBuilderApi.Presentation.Graphs.Metas;
using ChatbotBuilderApi.Presentation.Graphs.Ports;

namespace ChatbotBuilderApi.Presentation.Graphs.Nodes.Interaction;

/// <summary>
/// User Interaction node model:
/// <list type="bullet">
/// <item>Displays an output to the user (which matches the input ports of this node),
/// Then waits for the user input (which matches the output ports of this node).</item>
/// <item>At least one output port should exist, and at least one input port should exist.</item>
/// <item>More than one output port can exist but is optional, same for input ports.</item>
/// <item>If the port is an option, you can give each option some metadata to help the user.
/// This metadata will be retrieved and given to the caller when traversing the graph later.</item>
/// </list>
/// </summary>
/// <param name="Info">Generic information for the node.</param>
/// <param name="Visual">Visual information for the node.</param>
/// <param name="TextInputPort">Add this port if you want to display a text to the user.</param>
/// <param name="ImageInputPorts">(Max of 20) Add an Image port for each image you want to display to the user.
/// They will all be displayed to the user at once.</param>
/// <param name="TextOutputPort">Add this port if you want the user to input a text.</param>
/// <param name="OutputEnumId">Which enum to use for the OptionOutputPort.</param>
/// <param name="OptionOutputPort">Add this port if you want the user to select an option.</param>
/// <param name="OutputOptionMetas">A map of each option ID to its metadata. Stored for later use.</param>
public sealed record InteractionNodeModel(
    InfoMetaModel Info,
    VisualMetaModel Visual,
    InputPortModel? TextInputPort,
    IReadOnlyList<InputPortModel> ImageInputPorts,
    OutputPortModel? TextOutputPort,
    int? OutputEnumId,
    OutputPortModel? OptionOutputPort,
    IReadOnlyDictionary<string, InteractionOptionMetaModel>? OutputOptionMetas)
    : NodeModel(Info, Visual, NodeType.Interaction);

/// <summary>
/// Metadata for the options of the InteractionNodeModel.
/// </summary>
/// <param name="Description">String value containing the description of the option.</param>
public sealed record InteractionOptionMetaModel(string Description);