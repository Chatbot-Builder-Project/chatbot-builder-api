using ChatbotBuilderApi.Application.Graphs.Nodes.Abstract;
using ChatbotBuilderApi.Application.Graphs.Ports.InputPorts;
using ChatbotBuilderApi.Application.Graphs.Ports.OutputPorts;
using ChatbotBuilderApi.Domain.Graphs.Abstract.Services;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Meta;

namespace ChatbotBuilderApi.Application.Graphs.Nodes.ApiAction;

public sealed record ApiActionNodeDto(
    InfoMeta Info,
    VisualMeta Visual,
    InputPortDto UrlInputPort,
    ApiActionHttpMethod HttpMethod,
    IReadOnlyDictionary<string, string>? Headers,
    InputPortDto? BodyInputPort,
    OutputPortDto ResponseOutputPort
) : NodeDto(Info, Visual, NodeType.ApiAction),
    IInputNodeDto, IOutputNodeDto
{
    public IEnumerable<int> GetInputPortIds()
    {
        yield return UrlInputPort.Info.Identifier;

        if (BodyInputPort is not null)
        {
            yield return BodyInputPort.Info.Identifier;
        }
    }

    public IEnumerable<int> GetOutputPortIds()
    {
        yield return ResponseOutputPort.Info.Identifier;
    }
}