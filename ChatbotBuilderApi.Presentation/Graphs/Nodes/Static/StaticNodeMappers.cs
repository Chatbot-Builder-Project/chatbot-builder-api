using ChatbotBuilderApi.Application.Graphs.Nodes.Static;
using ChatbotBuilderApi.Presentation.Graphs.Data;
using ChatbotBuilderApi.Presentation.Graphs.Metas;
using ChatbotBuilderApi.Presentation.Graphs.Ports;
using Riok.Mapperly.Abstractions;

namespace ChatbotBuilderApi.Presentation.Graphs.Nodes.Static;

[Mapper]
public static partial class StaticNodeMappers
{
    public static StaticNodeModel ToModel(this StaticNodeDto dto)
    {
        return new StaticNodeModel(
            dto.Info.ToModel(),
            dto.Visual.ToModel(),
            dto.Data.MapToModel(),
            dto.OutputPort.ToModel());
    }

    public static StaticNodeDto ToDto(this StaticNodeModel model)
    {
        return new StaticNodeDto(
            model.Info.ToDomain(),
            model.Visual.ToDomain(),
            model.Data.MapToDomain(),
            model.OutputPort.ToDto());
    }
}