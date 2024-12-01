using ChatbotBuilderApi.Presentation.Features.Shared.Dtos.Workflows.Abstract;

namespace ChatbotBuilderApi.Presentation.Features.Shared.Dtos.Workflows.Components.Links;

public class FlowLinkDto : LinkDto
{
    public int InputNodeId { get; set; }
    public int OutputNodeId { get; set; }
}