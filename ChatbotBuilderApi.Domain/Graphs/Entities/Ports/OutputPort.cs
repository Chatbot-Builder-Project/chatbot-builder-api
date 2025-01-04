using ChatbotBuilderApi.Domain.Core;
using ChatbotBuilderApi.Domain.Graphs.Abstract;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Data;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Ids;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Meta;

namespace ChatbotBuilderApi.Domain.Graphs.Entities.Ports;

public sealed class OutputPort<TData> : Port<OutputPortId>
    where TData : Data
{
    private readonly HashSet<InputPort<TData>> _inputPorts = [];

    public IReadOnlySet<InputPort<TData>> InputPorts => _inputPorts;

    private OutputPort(
        OutputPortId id,
        InfoMeta info,
        VisualMeta visual,
        NodeId nodeId)
        : base(id, info, visual, nodeId)
    {
    }

    /// <inheritdoc/>
    private OutputPort()
    {
    }

    public static OutputPort<TData> Create(
        OutputPortId id,
        InfoMeta info,
        VisualMeta visual,
        NodeId nodeId)
    {
        return new OutputPort<TData>(id, info, visual, nodeId);
    }

    public void Subscribe(InputPort<TData> inputPort)
    {
        if (!_inputPorts.Add(inputPort))
        {
            throw new DomainException(GraphDomainErrors.OutputPort.InputPortAlreadySubscribed);
        }
    }

    public void Publish(TData data)
    {
        foreach (var inputPort in _inputPorts)
        {
            inputPort.SetData(data);
        }
    }
}