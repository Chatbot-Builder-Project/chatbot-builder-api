using ChatbotBuilderApi.Presentation.Features.Shared.Dtos.Workflows.Abstract;
using ChatbotBuilderApi.Presentation.Features.Shared.Dtos.Workflows.Enums;

namespace ChatbotBuilderApi.Presentation.Features.Shared.Dtos.Workflows.Components;

public class PortDto : VisualComponentDto
{
    public int NodeId { get; set; }
    public DataType DataType { get; set; }
    public PortDirection Direction { get; set; }
}