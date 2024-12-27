using ChatbotBuilderApi.Application.Graphs.Nodes.Abstract;
using ChatbotBuilderApi.Application.Graphs.Ports.InputPorts;
using ChatbotBuilderApi.Application.Graphs.Ports.OutputPorts;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Meta;

namespace ChatbotBuilderApi.Application.Graphs.Nodes.Prompt;

public sealed record PromptNodeDto(
    InfoMeta Info,
    VisualMeta Visual,
    PromptTemplateDto Template,
    OutputPortDto OutputPort,
    IReadOnlyList<InputPortDto> InputPorts
) : NodeDto(Info, Visual, NodeType.Prompt),
    IInputNodeDto, IOutputNodeDto
{
    public IEnumerable<int> GetInputPortIds()
    {
        return InputPorts.Select(inputPort => inputPort.Info.Identifier);
    }

    public IEnumerable<int> GetOutputPortIds()
    {
        yield return OutputPort.Info.Identifier;
    }
}