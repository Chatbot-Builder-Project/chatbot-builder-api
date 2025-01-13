using ChatbotBuilderApi.Application.Graphs.Ports.InputPorts;
using ChatbotBuilderApi.Application.Graphs.Ports.OutputPorts;
using ChatbotBuilderApi.Application.Graphs.Shared.Data;
using ChatbotBuilderApi.Domain.Graphs.Nodes;
using ChatbotBuilderApi.Domain.Graphs.Ports;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Data;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Ids;
using Riok.Mapperly.Abstractions;
using Enum = ChatbotBuilderApi.Domain.Graphs.Enum;

namespace ChatbotBuilderApi.Application.Graphs.Nodes.Interaction;

[Mapper]
public static partial class InteractionNodeMapper
{
    public static InteractionNode ToDomain(this InteractionNodeDto dto, Enum? outputEnum)
    {
        var nodeId = new NodeId(Guid.NewGuid());

        var textInputPort = dto.TextInputPort is null
            ? null
            : InputPort<TextData>.Create(
                new InputPortId(Guid.NewGuid()),
                dto.TextInputPort.Info,
                dto.TextInputPort.Visual,
                nodeId);

        var textOutputPort = dto.TextOutputPort is null
            ? null
            : OutputPort<TextData>.Create(
                new OutputPortId(Guid.NewGuid()),
                dto.TextOutputPort.Info,
                dto.TextOutputPort.Visual,
                nodeId);

        var optionOutputPort = dto.OptionOutputPort is null
            ? null
            : OutputPort<OptionData>.Create(
                new OutputPortId(Guid.NewGuid()),
                dto.OptionOutputPort.Info,
                dto.OptionOutputPort.Visual,
                nodeId);

        return InteractionNode.Create(
            nodeId,
            dto.Info,
            dto.Visual,
            textInputPort,
            dto.ImageInputPorts
                .Select(i => InputPort<ImageData>.Create(
                    new InputPortId(Guid.NewGuid()),
                    i.Info,
                    i.Visual,
                    nodeId))
                .ToHashSet(),
            textOutputPort,
            outputEnum,
            optionOutputPort,
            dto.OutputOptionMetas);
    }

    public static InteractionNodeDto ToDto(this InteractionNode domain)
    {
        var textInputPort = domain.TextInputPort is null
            ? null
            : new InputPortDto(
                domain.TextInputPort.Info,
                domain.TextInputPort.Visual,
                domain.Info.Identifier,
                DataType.Text);

        var textOutputPort = domain.TextOutputPort is null
            ? null
            : new OutputPortDto(
                domain.TextOutputPort.Info,
                domain.TextOutputPort.Visual,
                domain.Info.Identifier,
                DataType.Text);

        var optionOutputPort = domain.OptionOutputPort is null
            ? null
            : new OutputPortDto(
                domain.OptionOutputPort.Info,
                domain.OptionOutputPort.Visual,
                domain.Info.Identifier,
                DataType.Option);

        return new InteractionNodeDto(
            domain.Info,
            domain.Visual,
            textInputPort,
            domain.ImageInputPorts
                .Select(i => new InputPortDto(
                    i.Info,
                    i.Visual,
                    domain.Info.Identifier,
                    DataType.Image))
                .ToList(),
            textOutputPort,
            domain.OutputEnum?.Info.Identifier,
            optionOutputPort,
            domain.OutputOptionMetas);
    }
}