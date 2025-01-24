using ChatbotBuilderApi.Application.Graphs.Enums;
using ChatbotBuilderApi.Application.Graphs.Links.DataLinks;
using ChatbotBuilderApi.Application.Graphs.Links.FlowLinks;
using ChatbotBuilderApi.Application.Graphs.Nodes;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Meta;

namespace ChatbotBuilderApi.Application.Graphs;

public sealed record GraphDto(
    VisualMeta Visual,
    int StartNodeIdentifier,
    IReadOnlyList<NodeDto> Nodes,
    IReadOnlyList<DataLinkDto> DataLinks,
    IReadOnlyList<FlowLinkDto> FlowLinks,
    IReadOnlyList<EnumDto> Enums);