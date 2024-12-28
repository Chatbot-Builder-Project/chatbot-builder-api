using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Meta;

namespace ChatbotBuilderApi.Application.Graphs.Links.FlowLinks;

public sealed record FlowLinkDto(
    InfoMeta Info,
    VisualMeta Visual,
    int SourceNodeIdentifier,
    int TargetNodeIdentifier
) : LinkDto(Info, Visual);