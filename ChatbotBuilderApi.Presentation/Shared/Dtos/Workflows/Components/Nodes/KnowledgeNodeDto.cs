using ChatbotBuilderApi.Presentation.Shared.Dtos.Workflows.Abstract;

namespace ChatbotBuilderApi.Presentation.Shared.Dtos.Workflows.Components.Nodes;

/// <summary>
/// Storage for big information that cannot be passed to AI, but can be searched for relevant content.
/// Has a single text input port, and a single file input port.
/// </summary>
public class KnowledgeNodeDto : NodeDto
{
    public required PortDto TextInputPort { get; set; }
    public required PortDto FileInputPort { get; set; }
}