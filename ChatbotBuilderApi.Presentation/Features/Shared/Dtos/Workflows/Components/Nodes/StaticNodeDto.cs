using ChatbotBuilderApi.Presentation.Features.Shared.Dtos.Data;
using ChatbotBuilderApi.Presentation.Features.Shared.Dtos.Workflows.Abstract;

namespace ChatbotBuilderApi.Presentation.Features.Shared.Dtos.Workflows.Components.Nodes;

/// <summary>
/// Stores a constant value, has a single output port of data type similar to the stored value
/// </summary>
public class StaticNodeDto : NodeDto
{
    public required DataDto DataDto { get; set; }
    public required PortDto OutputPort { get; set; }
}