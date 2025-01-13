using ChatbotBuilderApi.Domain.Core;
using ChatbotBuilderApi.Domain.Graphs.Nodes.Behaviors;
using ChatbotBuilderApi.Domain.Graphs.Ports;
using ChatbotBuilderApi.Domain.Graphs.Traversal;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Data;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Ids;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Meta;

namespace ChatbotBuilderApi.Domain.Graphs.Nodes.Generation;

public sealed class GenerationNode : Node,
    IInputNode, IOutputNode
{
    public InputPort<TextData> InputPort { get; } = null!;
    public OutputPort<TextData> OutputPort { get; } = null!;
    public GenerationOptions Options { get; } = null!;

    public TextData? GeneratedOutput { get; private set; }

    private GenerationNode(
        NodeId id,
        InfoMeta info,
        VisualMeta visual,
        InputPort<TextData> inputPort,
        OutputPort<TextData> outputPort,
        GenerationOptions options)
        : base(id, info, visual)
    {
        InputPort = inputPort;
        OutputPort = outputPort;
        Options = options;
    }

    /// <inheritdoc/>
    private GenerationNode()
    {
    }

    public static GenerationNode Create(
        NodeId id,
        InfoMeta info,
        VisualMeta visual,
        InputPort<TextData> inputPort,
        OutputPort<TextData> outputPort,
        GenerationOptions options)
    {
        inputPort.EnsureNodeIdIs(id);
        outputPort.EnsureNodeIdIs(id);

        return new GenerationNode(id, info, visual, inputPort, outputPort, options);
    }

    public override async Task RunAsync(NodeExecutionContext context)
    {
        GeneratedOutput = await context.GenerationService.GenerateAsync(
            InputPort.GetData(),
            Options,
            Id.Value,
            CancellationToken.None);
    }

    public IEnumerable<Port<InputPortId>> GetInputPorts()
    {
        yield return InputPort;
    }

    public IEnumerable<Port<OutputPortId>> GetOutputPorts()
    {
        yield return OutputPort;
    }

    public void PublishOutputs()
    {
        if (GeneratedOutput is null)
        {
            throw new DomainException(GraphDomainErrors.GenerationNode.GeneratedOutputIsMissing);
        }

        OutputPort.Publish(GeneratedOutput);
    }
}