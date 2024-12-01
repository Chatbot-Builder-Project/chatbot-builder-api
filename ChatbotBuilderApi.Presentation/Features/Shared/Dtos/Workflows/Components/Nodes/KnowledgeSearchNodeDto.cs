using ChatbotBuilderApi.Presentation.Features.Shared.Dtos.Workflows.Abstract;

namespace ChatbotBuilderApi.Presentation.Features.Shared.Dtos.Workflows.Components.Nodes;

/// <summary>
/// Searches through a knowledge node for relevant context.
/// Has a single text input port, and a list of text output ports indicating the number of relevant chunks to retrieve
/// </summary>
public class KnowledgeSearchNodeDto : NodeDto
{
    public required PortDto InputPort { get; set; }
    public List<PortDto> OutputPorts { get; set; } = [];
    public int? KnowledgeNodeId { get; set; }
}