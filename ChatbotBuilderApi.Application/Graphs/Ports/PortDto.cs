using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Meta;

namespace ChatbotBuilderApi.Application.Graphs.Ports;

public abstract record PortDto(
    InfoMeta Info,
    VisualMeta Visual,
    PortDirection Direction,
    int NodeIdentifier);