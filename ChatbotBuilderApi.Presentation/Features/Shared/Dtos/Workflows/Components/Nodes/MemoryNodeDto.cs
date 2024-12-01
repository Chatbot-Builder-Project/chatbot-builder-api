using ChatbotBuilderApi.Presentation.Features.Shared.Dtos.Workflows.Abstract;

namespace ChatbotBuilderApi.Presentation.Features.Shared.Dtos.Workflows.Components.Nodes;

/// <summary>
/// Storage for an AI converstaion, can be used by generation nodes.
/// Has two text input ports for System & User messages.
/// </summary>
public class MemoryNodeDto : NodeDto
{
    public required PortDto SystemInputPort { get; set; }
    public required PortDto UserInputPort { get; set; }
}