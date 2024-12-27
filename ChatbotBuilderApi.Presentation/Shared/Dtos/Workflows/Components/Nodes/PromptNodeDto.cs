using ChatbotBuilderApi.Presentation.Shared.Dtos.Workflows.Abstract;

namespace ChatbotBuilderApi.Presentation.Shared.Dtos.Workflows.Components.Nodes;

/// <summary>
/// A text template that contains placeholders (in the format {{port_index}}), which are automatically filled with data
/// from the corresponding input ports when the prompt is used. Has a single Text output port,
/// typically connected to a Generation or an Output node.
/// Output port should be of Text data type, and number of input ports should match the number of placeholders
/// in the template, and all ports should be of Text data type.
/// </summary>
public class PromptNodeDto : NodeDto
{
    public string Template { get; set; } = string.Empty;
    public required PortDto OutputPort { get; set; }
    public List<PortDto> InputPorts { get; set; } = [];
}