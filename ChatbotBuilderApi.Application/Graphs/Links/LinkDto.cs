using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Meta;

namespace ChatbotBuilderApi.Application.Graphs.Links;

public abstract record LinkDto(
    InfoMeta Info,
    VisualMeta Visual);