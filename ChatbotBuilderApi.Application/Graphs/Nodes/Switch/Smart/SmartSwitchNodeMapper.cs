using ChatbotBuilderApi.Application.Graphs.Ports.InputPorts;
using ChatbotBuilderApi.Application.Graphs.Shared.Data;
using ChatbotBuilderApi.Domain.Graphs.Nodes.Switch;
using ChatbotBuilderApi.Domain.Graphs.Ports;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Data;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Ids;
using Riok.Mapperly.Abstractions;
using Enum = ChatbotBuilderApi.Domain.Graphs.Enum;

namespace ChatbotBuilderApi.Application.Graphs.Nodes.Switch.Smart;

[Mapper]
public static partial class SmartSwitchNodeMapper
{
    public static SmartSwitchNode ToDomain(
        this SmartSwitchNodeDto dto,
        Enum @enum,
        IReadOnlyDictionary<OptionData, FlowLinkId> bindings)
    {
        var nodeId = new NodeId(Guid.NewGuid());
        return SmartSwitchNode.Create(
            nodeId,
            dto.Info,
            dto.Visual,
            InputPort<TextData>.Create(
                new InputPortId(Guid.NewGuid()),
                dto.InputPort.Info,
                dto.InputPort.Visual,
                nodeId),
            @enum,
            bindings);
    }

    public static SmartSwitchNodeDto ToDto(
        this SmartSwitchNode domain,
        IReadOnlyDictionary<OptionData, int> bindings)
    {
        return new SmartSwitchNodeDto(
            domain.Info,
            domain.Visual,
            new InputPortDto(
                domain.InputPort.Info,
                domain.InputPort.Visual,
                domain.Info.Identifier,
                DataType.Text),
            domain.Enum.Info.Identifier,
            bindings);
    }
}