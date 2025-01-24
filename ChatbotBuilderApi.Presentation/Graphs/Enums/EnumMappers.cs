using ChatbotBuilderApi.Application.Graphs.Enums;
using ChatbotBuilderApi.Presentation.Graphs.Data;
using ChatbotBuilderApi.Presentation.Graphs.Metas;
using Riok.Mapperly.Abstractions;

namespace ChatbotBuilderApi.Presentation.Graphs.Enums;

[Mapper]
public static partial class EnumMappers
{
    public static EnumModel ToModel(this EnumDto dto)
    {
        return new EnumModel(
            dto.Info.ToModel(),
            dto.Visual.ToModel(),
            dto.Options.Select(o => o.ToModel()).ToList());
    }

    public static EnumDto ToDto(this EnumModel model)
    {
        return new EnumDto(
            model.Info.ToDomain(),
            model.Visual.ToDomain(),
            model.Options.Select(o => o.ToDomain()).ToList());
    }
}