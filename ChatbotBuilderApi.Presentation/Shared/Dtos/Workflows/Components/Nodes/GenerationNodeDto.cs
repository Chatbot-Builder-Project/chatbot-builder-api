using ChatbotBuilderApi.Presentation.Shared.Dtos.Workflows.Abstract;

namespace ChatbotBuilderApi.Presentation.Shared.Dtos.Workflows.Components.Nodes;

/// <summary>
/// Generates content based on a prompt, so a single input port. And can be configured to use a memory.
/// Both input and output ports should be of Text data type.
/// It can have a memory node that can be used during generation
/// </summary>
public class GenerationNodeDto : NodeDto
{
    public required PortDto InputPort { get; set; }
    public required PortDto OutputPort { get; set; }
    public int? MemoryNodeId { get; set; }
}