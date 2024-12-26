using ChatbotBuilderApi.Application.Graphs.Ports;
using ChatbotBuilderApi.Application.Graphs.Ports.InputPorts;
using ChatbotBuilderApi.Application.Graphs.Ports.OutputPorts;
using ChatbotBuilderApi.Application.Graphs.Shared.Data;
using ChatbotBuilderApi.Domain.Graphs.Entities.Nodes.Prompt;
using ChatbotBuilderApi.Domain.Graphs.Entities.Ports;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Data;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Ids;
using Riok.Mapperly.Abstractions;

namespace ChatbotBuilderApi.Application.Graphs.Nodes.Prompt;

[Mapper]
public static partial class PromptNodeMapper
{
    public static PromptNode ToDomain(this PromptNodeDto dto)
    {
        var nodeId = new NodeId(Guid.NewGuid());
        return PromptNode.Create(
            nodeId,
            dto.Info,
            dto.Visual,
            dto.Template.ToDomain(),
            OutputPort<TextData>.Create(
                new OutputPortId(Guid.NewGuid()),
                dto.OutputPort.Info,
                dto.OutputPort.Visual,
                nodeId),
            dto.InputPorts
                .Select(i => InputPort<TextData>.Create(
                    new InputPortId(Guid.NewGuid()),
                    i.Info,
                    i.Visual,
                    nodeId))
                .ToList());
    }

    public static PromptNodeDto ToDto(this PromptNode domain)
    {
        return new PromptNodeDto(
            domain.Info,
            domain.Visual,
            NodeType.Prompt,
            domain.Template.ToDto(),
            new OutputPortDto(
                domain.OutputPort.Info,
                domain.OutputPort.Visual,
                PortDirection.Output,
                domain.Info.Identifier,
                DataType.Text),
            domain.InputPorts
                .Select(i => new InputPortDto(
                    i.Info,
                    i.Visual,
                    PortDirection.Input,
                    domain.Info.Identifier,
                    DataType.Text))
                .ToList());
    }
}