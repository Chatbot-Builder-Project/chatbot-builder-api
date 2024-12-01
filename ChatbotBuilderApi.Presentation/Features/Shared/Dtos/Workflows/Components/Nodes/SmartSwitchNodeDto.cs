namespace ChatbotBuilderApi.Presentation.Features.Shared.Dtos.Workflows.Components.Nodes;

/// <summary>
/// A switch that can intelligently determine the output option that fits a given text input the most,
/// so it should have a single Text input port.
/// It has an extra flow link, in case no option fits the text input  fallback flow is chosen
/// (it should have this switch node as its input)
/// </summary>
public class SmartSwitchNodeDto : SwitchNodeDto
{
    public int FallBackFlowLinkId { get; set; }
}