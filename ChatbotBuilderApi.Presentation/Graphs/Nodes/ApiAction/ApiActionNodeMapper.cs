using ChatbotBuilderApi.Application.Graphs.Nodes.ApiAction;
using ChatbotBuilderApi.Presentation.Graphs.Metas;
using ChatbotBuilderApi.Presentation.Graphs.Ports;
using Riok.Mapperly.Abstractions;

namespace ChatbotBuilderApi.Presentation.Graphs.Nodes.ApiAction;

[Mapper]
public static partial class ApiActionNodeMapper
{
    public static ApiActionNodeModel ToModel(this ApiActionNodeDto dto)
    {
        return new ApiActionNodeModel(
            dto.Info.ToModel(),
            dto.Visual.ToModel(),
            dto.UrlInputPort.ToModel(),
            dto.HttpMethod,
            dto.Headers,
            dto.BodyInputPort?.ToModel(),
            dto.ResponseOutputPort.ToModel());
    }

    public static ApiActionNodeDto ToDto(this ApiActionNodeModel model)
    {
        return new ApiActionNodeDto(
            model.Info.ToDomain(),
            model.Visual.ToDomain(),
            model.UrlInputPort.ToDto(),
            model.HttpMethod,
            model.Headers,
            model.BodyInputPort?.ToDto(),
            model.ResponseOutputPort.ToDto());
    }
}