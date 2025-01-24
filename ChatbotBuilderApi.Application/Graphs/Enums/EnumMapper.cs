using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Ids;
using Riok.Mapperly.Abstractions;
using Enum = ChatbotBuilderApi.Domain.Graphs.Enum;

namespace ChatbotBuilderApi.Application.Graphs.Enums;

[Mapper]
public static partial class EnumMapper
{
    public static Enum ToDomain(this EnumDto dto)
    {
        return Enum.Create(
            new EnumId(Guid.NewGuid()),
            dto.Info,
            dto.Visual,
            dto.Options.ToHashSet());
    }

    public static EnumDto ToDto(this Enum domain)
    {
        return new EnumDto(
            domain.Info,
            domain.Visual,
            domain.Options.ToList());
    }
}