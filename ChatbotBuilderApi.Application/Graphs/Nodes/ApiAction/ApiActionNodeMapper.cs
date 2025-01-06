using ChatbotBuilderApi.Application.Graphs.Ports.InputPorts;
using ChatbotBuilderApi.Application.Graphs.Ports.OutputPorts;
using ChatbotBuilderApi.Application.Graphs.Shared.Data;
using ChatbotBuilderApi.Domain.Graphs.Nodes.ApiAction;
using ChatbotBuilderApi.Domain.Graphs.Ports;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Data;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Ids;
using Riok.Mapperly.Abstractions;

namespace ChatbotBuilderApi.Application.Graphs.Nodes.ApiAction;

[Mapper]
public static partial class ApiActionNodeMapper
{
    public static ApiActionNode ToDomain(this ApiActionNodeDto dto)
    {
        var nodeId = new NodeId(Guid.NewGuid());

        var urlInputPort = InputPort<TextData>.Create(
            new InputPortId(Guid.NewGuid()),
            dto.UrlInputPort.Info,
            dto.UrlInputPort.Visual,
            nodeId);

        var bodyInputPort = dto.BodyInputPort == null
            ? null
            : InputPort<TextData>.Create(
                new InputPortId(Guid.NewGuid()),
                dto.BodyInputPort.Info,
                dto.BodyInputPort.Visual,
                nodeId);

        var responseOutputPort = OutputPort<TextData>.Create(
            new OutputPortId(Guid.NewGuid()),
            dto.ResponseOutputPort.Info,
            dto.ResponseOutputPort.Visual,
            nodeId);

        return ApiActionNode.Create(
            nodeId,
            dto.Info,
            dto.Visual,
            urlInputPort,
            dto.HttpMethod,
            dto.Headers,
            bodyInputPort,
            responseOutputPort);
    }

    public static ApiActionNodeDto ToDto(this ApiActionNode domain)
    {
        return new ApiActionNodeDto(
            domain.Info,
            domain.Visual,
            new InputPortDto(
                domain.UrlInputPort.Info,
                domain.UrlInputPort.Visual,
                domain.Info.Identifier,
                DataType.Text),
            domain.HttpMethod,
            domain.Headers,
            domain.BodyInputPort == null
                ? null
                : new InputPortDto(
                    domain.BodyInputPort.Info,
                    domain.BodyInputPort.Visual,
                    domain.Info.Identifier,
                    DataType.Text),
            new OutputPortDto(
                domain.ResponseOutputPort.Info,
                domain.ResponseOutputPort.Visual,
                domain.Info.Identifier,
                DataType.Text));
    }
}