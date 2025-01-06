using ChatbotBuilderApi.Domain.Graphs.Ports;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Ids;

namespace ChatbotBuilderApi.Domain.Graphs.Nodes.Behaviors;

/// <summary>
/// A node that can have inputs.
/// </summary>
public interface IInputNode
{
    IEnumerable<Port<InputPortId>> GetInputPorts();
}