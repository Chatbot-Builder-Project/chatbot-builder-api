using ChatbotBuilderApi.Application.Graphs.Ports.InputPorts;
using ChatbotBuilderApi.Application.Graphs.Ports.OutputPorts;
using ChatbotBuilderApi.Application.Graphs.Shared.Data;
using ChatbotBuilderApi.Domain.Graphs.Nodes.Generation;
using ChatbotBuilderApi.Domain.Graphs.Ports;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Data;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Ids;
using Riok.Mapperly.Abstractions;

namespace ChatbotBuilderApi.Application.Graphs.Nodes.Generation;

[Mapper]
public static partial class GenerationNodeMapper
{
    public static GenerationNode ToDomain(
        this GenerationNodeDto dto)
    {
        var nodeId = new NodeId(Guid.NewGuid());
        return GenerationNode.Create(
            nodeId,
            dto.Info,
            dto.Visual,
            InputPort<TextData>.Create(
                new InputPortId(Guid.NewGuid()),
                dto.InputPort.Info,
                dto.InputPort.Visual,
                nodeId),
            OutputPort<TextData>.Create(
                new OutputPortId(Guid.NewGuid()),
                dto.OutputPort.Info,
                dto.OutputPort.Visual,
                nodeId),
            dto.Options);
    }

    public static GenerationNodeDto ToDto(
        this GenerationNode domain)
    {
        return new GenerationNodeDto(
            domain.Info,
            domain.Visual,
            new InputPortDto(
                domain.InputPort.Info,
                domain.InputPort.Visual,
                domain.Info.Identifier,
                DataType.Text),
            new OutputPortDto(
                domain.OutputPort.Info,
                domain.OutputPort.Visual,
                domain.Info.Identifier,
                DataType.Text),
            domain.Options);
    }
}