using ChatbotBuilderApi.Domain.Graphs.Nodes.Behaviors;
using ChatbotBuilderApi.Domain.Graphs.Ports;
using ChatbotBuilderApi.Domain.Graphs.Traversal;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Data;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Ids;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Meta;

namespace ChatbotBuilderApi.Domain.Graphs.Nodes.Switch;

public sealed class SmartSwitchNode : SwitchNodeBase, IInputNode
{
    public InputPort<TextData> InputPort { get; } = null!;

    private SmartSwitchNode(
        NodeId id,
        InfoMeta info,
        VisualMeta visual,
        InputPort<TextData> inputPort,
        Enum @enum,
        IReadOnlyDictionary<OptionData, FlowLinkId> bindings)
        : base(id, info, visual, @enum, bindings)
    {
        InputPort = inputPort;
    }

    /// <inheritdoc/>
    private SmartSwitchNode()
    {
    }

    public static SmartSwitchNode Create(
        NodeId id,
        InfoMeta info,
        VisualMeta visual,
        InputPort<TextData> inputPort,
        Enum @enum,
        IReadOnlyDictionary<OptionData, FlowLinkId> bindings)
    {
        @enum.EnsureValidBindings(bindings);
        inputPort.EnsureNodeIdIs(id);

        return new SmartSwitchNode(id, info, visual, inputPort, @enum, bindings);
    }

    public override Task RunAsync(NodeExecutionContext context)
    {
        throw new NotImplementedException("Smart switch nodes are not supported yet.");
    }

    public IEnumerable<Port<InputPortId>> GetInputPorts()
    {
        yield return InputPort;
    }
}