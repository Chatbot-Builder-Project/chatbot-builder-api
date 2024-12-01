using ChatbotBuilderApi.Presentation.Features.Shared.Dtos.Workflows.Abstract;

namespace ChatbotBuilderApi.Presentation.Features.Shared.Dtos.Workflows.Components.Nodes;

/// <summary>
/// A container that encapsulates a resusable sub-flow that can be used many times as a single component
/// </summary>
public class GroupNodeDto : NodeDto
{
    /// <summary>
    /// Input and output port of the group node
    /// </summary>
    public List<PortDto> Ports { get; set; } = [];

    /// <summary>
    /// A single active start node, the input ports of the group node must match the start node's input ports
    /// </summary>
    public int StartNodeId { get; set; }

    /// <summary>
    /// Includes the start node, must have at least one node
    /// </summary>
    public List<int> NodeIds { get; set; } = [];

    /// <summary>
    /// Includes all data links between internal ports and output ports of the group node.
    /// (Optional) data links between input ports of the group node and input ports of the start node
    /// </summary>
    public List<int> DataLinkIds { get; set; } = [];

    public List<int> FlowLinkIds { get; set; } = [];
}