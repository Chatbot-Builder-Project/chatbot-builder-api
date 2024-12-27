using ChatbotBuilderApi.Application.Graphs.Nodes.Abstract;
using ChatbotBuilderApi.Application.Graphs.Ports.OutputPorts;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Data;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Meta;

namespace ChatbotBuilderApi.Application.Graphs.Nodes.Static;

public sealed record StaticNodeDto(
    InfoMeta Info,
    VisualMeta Visual,
    Data Data,
    OutputPortDto OutputPort
) : NodeDto(Info, Visual, NodeType.Static),
    IOutputNodeDto
{
    public IEnumerable<int> GetOutputPortIds()
    {
        yield return OutputPort.Info.Identifier;
    }
}