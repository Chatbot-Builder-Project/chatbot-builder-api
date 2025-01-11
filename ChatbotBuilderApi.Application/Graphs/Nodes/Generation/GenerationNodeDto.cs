using ChatbotBuilderApi.Application.Graphs.Nodes.Abstract;
using ChatbotBuilderApi.Application.Graphs.Ports.InputPorts;
using ChatbotBuilderApi.Application.Graphs.Ports.OutputPorts;
using ChatbotBuilderApi.Domain.Graphs.Nodes.Generation;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Meta;

namespace ChatbotBuilderApi.Application.Graphs.Nodes.Generation;

public sealed record GenerationNodeDto(
    InfoMeta Info,
    VisualMeta Visual,
    InputPortDto InputPort,
    OutputPortDto OutputPort,
    GenerationOptions Options
) : NodeDto(Info, Visual, NodeType.Generation),
    IInputNodeDto, IOutputNodeDto
{
    public IEnumerable<int> GetInputPortIds()
    {
        yield return InputPort.Info.Identifier;
    }

    public IEnumerable<int> GetOutputPortIds()
    {
        yield return OutputPort.Info.Identifier;
    }
}