using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Meta;

namespace ChatbotBuilderApi.Application.Graphs.Nodes;

public abstract record NodeDto(
    InfoMeta Info,
    VisualMeta Visual,
    NodeType Type
);