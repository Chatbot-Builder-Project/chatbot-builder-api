using ChatbotBuilderApi.Presentation.Features.Shared.Dtos.Workflows.Abstract;
using ChatbotBuilderApi.Presentation.Features.Shared.Dtos.Workflows.Components;
using ChatbotBuilderApi.Presentation.Features.Shared.Dtos.Workflows.Components.Links;

namespace ChatbotBuilderApi.Presentation.Features.Shared.Dtos.Workflows;

public class WorkflowComponentsDto
{
    public List<NodeDto> Nodes { get; set; } = [];
    public int StartNodeId { get; set; }
    public List<DataLinkDto> DataLinks { get; set; } = [];
    public List<FlowLinkDto> FlowLinks { get; set; } = [];
    public List<EnumDto> Enums { get; set; } = [];
}