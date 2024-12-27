using ChatbotBuilderApi.Presentation.Shared.Dtos.Workflows.Abstract;

namespace ChatbotBuilderApi.Presentation.Shared.Dtos.Workflows.Components.Links;

public class DataLinkDto : LinkDto
{
    public int InputPortId { get; set; }
    public int OutputPortId { get; set; }
}