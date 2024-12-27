using ChatbotBuilderApi.Presentation.Shared.Dtos.Workflows.Abstract;

namespace ChatbotBuilderApi.Presentation.Shared.Dtos.Workflows.Components.Nodes;

/// <summary>
/// Routes the flow based on a provided option, so every option of the enum corresponds to a flow link.
/// Takes an option input, and statically determines the flow link to route to
/// All flow links should have this switch node as their input node.
/// The input port should be of Option data type
/// </summary>
public class SwitchNodeDto : NodeDto
{
    public required PortDto InputPort { get; set; }
    public int EnumId { get; set; }
    public Dictionary<string, int> OptionFlowLinkIds { get; set; } = new();
}