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
            dto.Options.ToHashSet());
    }

    public static partial EnumDto ToDto(this Enum domain);
}