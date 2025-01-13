using ChatbotBuilderApi.Domain.Graphs.Nodes.Behaviors;
using ChatbotBuilderApi.Domain.Graphs.Ports;
using ChatbotBuilderApi.Domain.Graphs.Traversal;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Data;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Ids;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Meta;

namespace ChatbotBuilderApi.Domain.Graphs.Nodes.Switch;

public sealed class SwitchNode : SwitchNodeBase, IInputNode
{
    public InputPort<OptionData> InputPort { get; } = null!;

    private SwitchNode(
        NodeId id,
        InfoMeta info,
        VisualMeta visual,
        InputPort<OptionData> inputPort,
        Enum @enum,
        IReadOnlyDictionary<OptionData, FlowLinkId> bindings)
        : base(id, info, visual, @enum, bindings)
    {
        InputPort = inputPort;
    }

    /// <inheritdoc/>
    private SwitchNode()
    {
    }

    public static SwitchNode Create(
        NodeId id,
        InfoMeta info,
        VisualMeta visual,
        InputPort<OptionData> inputPort,
        Enum @enum,
        IReadOnlyDictionary<OptionData, FlowLinkId> bindings)
    {
        return new SwitchNode(
            id,
            info,
            visual,
            inputPort,
            @enum,
            bindings);
    }

    public override Task RunAsync(NodeExecutionContext context)
    {
        SelectedOption = InputPort.GetData();
        return Task.CompletedTask;
    }

    public IEnumerable<Port<InputPortId>> GetInputPorts()
    {
        yield return InputPort;
    }
}