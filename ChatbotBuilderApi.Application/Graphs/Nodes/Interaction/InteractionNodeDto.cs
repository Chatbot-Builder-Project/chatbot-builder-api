using ChatbotBuilderApi.Application.Graphs.Nodes.Abstract;
using ChatbotBuilderApi.Application.Graphs.Ports.InputPorts;
using ChatbotBuilderApi.Application.Graphs.Ports.OutputPorts;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Data;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Interactions;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Meta;

namespace ChatbotBuilderApi.Application.Graphs.Nodes.Interaction;

public sealed record InteractionNodeDto(
    InfoMeta Info,
    VisualMeta Visual,
    NodeType Type,
    InputPortDto? TextInputPort,
    OutputPortDto? TextOutputPort,
    int? OutputEnumIdentifier,
    OutputPortDto? OptionOutputPort,
    IReadOnlyDictionary<OptionData, InteractionOptionMeta>? OutputOptionMetas
) : NodeDto(Info, Visual, Type),
    IInputNodeDto, IEnumNodeDto, IOutputNodeDto
{
    public IEnumerable<int> GetInputPortIds()
    {
        if (TextOutputPort is not null)
        {
            yield return TextOutputPort.Info.Identifier;
        }
    }

    public IEnumerable<int> GetEnumIds()
    {
        if (OutputEnumIdentifier is not null)
        {
            yield return OutputEnumIdentifier.Value;
        }
    }

    public IEnumerable<int> GetOutputPortIds()
    {
        if (TextOutputPort is not null)
        {
            yield return TextOutputPort.Info.Identifier;
        }

        if (OptionOutputPort is not null)
        {
            yield return OptionOutputPort.Info.Identifier;
        }
    }
}