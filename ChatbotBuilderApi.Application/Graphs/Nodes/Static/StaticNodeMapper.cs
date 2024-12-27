using ChatbotBuilderApi.Application.Graphs.Ports.OutputPorts;
using ChatbotBuilderApi.Application.Graphs.Shared.Data.Extensions;
using ChatbotBuilderApi.Domain.Graphs.Entities.Nodes;
using ChatbotBuilderApi.Domain.Graphs.Entities.Ports;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Data;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Ids;
using Riok.Mapperly.Abstractions;

namespace ChatbotBuilderApi.Application.Graphs.Nodes.Static;

[Mapper]
public static partial class StaticNodeMapper
{
    public static StaticNode<TData> ToDomain<TData>(this StaticNodeDto dto)
        where TData : Data
    {
        var nodeId = new NodeId(Guid.NewGuid());
        return StaticNode<TData>.Create(
            nodeId,
            dto.Info,
            dto.Visual,
            (TData)dto.Data,
            OutputPort<TData>.Create(
                new OutputPortId(Guid.NewGuid()),
                dto.OutputPort.Info,
                dto.OutputPort.Visual,
                nodeId));
    }

    public static StaticNodeDto ToDto<TData>(this StaticNode<TData> domain)
        where TData : Data
    {
        return new StaticNodeDto(
            domain.Info,
            domain.Visual,
            NodeType.Static,
            domain.Data.ToDataType(),
            domain.Data,
            new OutputPortDto(
                domain.OutputPort.Info,
                domain.OutputPort.Visual,
                domain.Info.Identifier,
                domain.Data.ToDataType()));
    }
}