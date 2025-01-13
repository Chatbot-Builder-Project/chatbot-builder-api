using ChatbotBuilderApi.Domain.Graphs.Nodes.Behaviors;
using ChatbotBuilderApi.Domain.Graphs.Ports;
using ChatbotBuilderApi.Domain.Graphs.Traversal;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Data;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Ids;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Meta;

namespace ChatbotBuilderApi.Domain.Graphs.Nodes.Switch.Smart;

public sealed class SmartSwitchNode : SwitchNodeBase, IInputNode
{
    public InputPort<TextData> InputPort { get; } = null!;
    public FlowLinkId FallbackFlowLinkId { get; } = null!;

    private SmartSwitchNode(
        NodeId id,
        InfoMeta info,
        VisualMeta visual,
        InputPort<TextData> inputPort,
        Enum @enum,
        IReadOnlyDictionary<OptionData, FlowLinkId> bindings,
        FlowLinkId fallbackFlowLinkId)
        : base(id, info, visual, @enum, bindings)
    {
        InputPort = inputPort;
        FallbackFlowLinkId = fallbackFlowLinkId;
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
        IReadOnlyDictionary<OptionData, FlowLinkId> bindings,
        FlowLinkId fallbackFlowLinkId)
    {
        @enum.EnsureValidBindings(bindings);
        inputPort.EnsureNodeIdIs(id);

        return new SmartSwitchNode(id, info, visual, inputPort, @enum, bindings, fallbackFlowLinkId);
    }

    public override async Task RunAsync(NodeExecutionContext context)
    {
        SelectedOption = await context.SmartRoutingService.RouteAsync(
            InputPort.GetData(),
            Enum.Options,
            CancellationToken.None);
    }

    public IEnumerable<Port<InputPortId>> GetInputPorts()
    {
        yield return InputPort;
    }

    public override IEnumerable<FlowLinkId> GetFlowLinkIds()
    {
        foreach (var flowLinkId in base.GetFlowLinkIds())
        {
            yield return flowLinkId;
        }

        yield return FallbackFlowLinkId;
    }
}