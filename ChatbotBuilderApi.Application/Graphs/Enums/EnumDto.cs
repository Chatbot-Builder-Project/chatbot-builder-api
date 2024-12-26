using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Data;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Meta;

namespace ChatbotBuilderApi.Application.Graphs.Enums;

public sealed record EnumDto(
    InfoMeta Info,
    IReadOnlyList<OptionData> Options);