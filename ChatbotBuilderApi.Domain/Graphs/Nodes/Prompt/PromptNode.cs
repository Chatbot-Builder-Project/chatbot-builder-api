﻿using ChatbotBuilderApi.Domain.Core;
using ChatbotBuilderApi.Domain.Graphs.Nodes.Behaviors;
using ChatbotBuilderApi.Domain.Graphs.Ports;
using ChatbotBuilderApi.Domain.Graphs.Traversal;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Data;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Ids;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Meta;

namespace ChatbotBuilderApi.Domain.Graphs.Nodes.Prompt;

public sealed class PromptNode : Node,
    IInputNode, IOutputNode
{
    public PromptTemplate Template { get; } = null!;
    public OutputPort<TextData> OutputPort { get; } = null!;
    public IReadOnlySet<InputPort<TextData>> InputPorts { get; } = null!;
    public string? InjectedTemplate { get; private set; }

    private PromptNode(
        NodeId id,
        InfoMeta info,
        VisualMeta visual,
        PromptTemplate template,
        OutputPort<TextData> outputPort,
        IReadOnlySet<InputPort<TextData>> inputPorts)
        : base(id, info, visual)
    {
        Template = template;
        OutputPort = outputPort;
        InputPorts = inputPorts;
    }

    /// <inheritdoc/>
    private PromptNode()
    {
    }

    public static PromptNode Create(
        NodeId id,
        InfoMeta info,
        VisualMeta visual,
        PromptTemplate template,
        OutputPort<TextData> outputPort,
        IReadOnlyList<InputPort<TextData>> inputPorts)
    {
        // Make sure it doesn't throw an exception
        var values = inputPorts.ToDictionary(
            ip => ip.Info.Identifier.ToString(),
            _ => string.Empty);
        template.InjectValues(values);

        outputPort.EnsureNodeIdIs(id);
        foreach (var inputPort in inputPorts)
        {
            inputPort.EnsureNodeIdIs(id);
        }

        var inputPortsSet = new HashSet<InputPort<TextData>>();
        foreach (var inputPort in inputPorts)
        {
            if (!inputPortsSet.Add(inputPort))
            {
                throw new DomainException(GraphDomainErrors.PromptNode.DuplicateInputPorts);
            }
        }

        return new PromptNode(id, info, visual, template, outputPort, inputPortsSet);
    }

    public override Task RunAsync(NodeExecutionContext context)
    {
        var values = InputPorts.ToDictionary(
            ip => ip.Info.Identifier.ToString(),
            ip => ip.GetData().Text);

        InjectedTemplate = Template.InjectValues(values);
        return Task.CompletedTask;
    }

    public IEnumerable<Port<InputPortId>> GetInputPorts()
    {
        return InputPorts;
    }

    public IEnumerable<Port<OutputPortId>> GetOutputPorts()
    {
        yield return OutputPort;
    }

    public void PublishOutputs()
    {
        if (InjectedTemplate is null)
        {
            throw new DomainException(GraphDomainErrors.PromptNode.NodeHasNotBeenActivated);
        }

        OutputPort.Publish(TextData.Create(InjectedTemplate));
    }
}