using ChatbotBuilderApi.Domain.Graphs.Abstract;
using ChatbotBuilderApi.Domain.Graphs.Abstract.Behaviors;
using ChatbotBuilderApi.Domain.Graphs.Entities.Ports;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Data;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Ids;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Meta;

namespace ChatbotBuilderApi.Domain.Graphs.Entities.Nodes;

public sealed class StaticNode<TOutputData> : Node,
    ISetupNode, IOutputNode
    where TOutputData : Data
{
    public TOutputData Data { get; } = null!;
    public OutputPort<TOutputData> OutputPort { get; } = null!;

    private StaticNode(
        NodeId id,
        InfoMeta info,
        VisualMeta visual,
        TOutputData data,
        OutputPort<TOutputData> outputPort)
        : base(id, info, visual)
    {
        Data = data;
        OutputPort = outputPort;
    }

    /// <inheritdoc/>
    private StaticNode()
    {
    }

    public static StaticNode<TOutputData> Create(
        NodeId id,
        InfoMeta info,
        VisualMeta visual,
        TOutputData data,
        OutputPort<TOutputData> outputPort)
    {
        outputPort.EnsureNodeIdIs(id);
        return new StaticNode<TOutputData>(id, info, visual, data, outputPort);
    }

    public IEnumerable<Port<OutputPortId>> GetOutputPorts()
    {
        yield return OutputPort;
    }

    public void PublishOutputs()
    {
        OutputPort.Publish(Data);
    }
}