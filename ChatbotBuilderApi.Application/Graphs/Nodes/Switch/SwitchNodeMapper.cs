using ChatbotBuilderApi.Application.Graphs.Ports.InputPorts;
using ChatbotBuilderApi.Application.Graphs.Shared.Data;
using ChatbotBuilderApi.Domain.Graphs.Entities.Nodes;
using ChatbotBuilderApi.Domain.Graphs.Entities.Ports;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Data;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Ids;
using Riok.Mapperly.Abstractions;
using Enum = ChatbotBuilderApi.Domain.Graphs.Entities.Enum;

namespace ChatbotBuilderApi.Application.Graphs.Nodes.Switch;

[Mapper]
public static partial class SwitchNodeMapper
{
    public static SwitchNode ToDomain(
        this SwitchNodeDto dto,
        Enum @enum,
        IReadOnlyDictionary<OptionData, FlowLinkId> bindings)
    {
        var nodeId = new NodeId(Guid.NewGuid());
        return SwitchNode.Create(
            nodeId,
            dto.Info,
            dto.Visual,
            InputPort<OptionData>.Create(
                new InputPortId(Guid.NewGuid()),
                dto.InputPort.Info,
                dto.InputPort.Visual,
                nodeId),
            @enum,
            bindings);
    }

    public static SwitchNodeDto ToDto(
        this SwitchNode domain,
        IReadOnlyDictionary<OptionData, int> bindings)
    {
        return new SwitchNodeDto(
            domain.Info,
            domain.Visual,
            new InputPortDto(
                domain.InputPort.Info,
                domain.InputPort.Visual,
                domain.Info.Identifier,
                DataType.Option),
            domain.Enum.Info.Identifier,
            bindings);
    }
}