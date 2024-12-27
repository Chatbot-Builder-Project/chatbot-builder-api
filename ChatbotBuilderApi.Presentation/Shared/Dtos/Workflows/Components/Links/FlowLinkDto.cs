using ChatbotBuilderApi.Presentation.Shared.Dtos.Workflows.Abstract;

namespace ChatbotBuilderApi.Presentation.Shared.Dtos.Workflows.Components.Links;

public class FlowLinkDto : LinkDto
{
    public int InputNodeId { get; set; }
    public int OutputNodeId { get; set; }
}