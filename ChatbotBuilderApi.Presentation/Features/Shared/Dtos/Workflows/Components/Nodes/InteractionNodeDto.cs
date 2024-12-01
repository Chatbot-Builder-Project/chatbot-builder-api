namespace ChatbotBuilderApi.Presentation.Features.Shared.Dtos.Workflows.Components.Nodes;

/// <summary>
/// Displays output to user, which matches the input ports of this node.
/// Then waits for the user input, which matches the output ports of this node
/// (Output ports match the user input, Input port match the values displayed to the user)
/// At least one output port should exist, and at least one input port should exist.
/// If the port is an option, you can give each possible option a description to help the user
/// </summary>
public class InteractionNodeDto
{
    public PortDto? TextOutputPort { get; set; }
    public PortDto? OptionOutputPort { get; set; }
    public PortDto? TextInputPort { get; set; }
    public PortDto? OptionInputPort { get; set; }
    public Dictionary<string, string>? OutputOptionDescriptions { get; set; }
    public Dictionary<string, string>? InputOptionDescriptions { get; set; }
}