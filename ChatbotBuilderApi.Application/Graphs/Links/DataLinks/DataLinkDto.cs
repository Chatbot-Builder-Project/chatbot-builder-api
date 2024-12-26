using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Meta;

namespace ChatbotBuilderApi.Application.Graphs.Links.DataLinks;

public sealed record DataLinkDto(
    InfoMeta Info,
    VisualMeta Visual,
    int InputPortIdentifier,
    int OutputPortIdentifier
) : LinkDto(Info, Visual);