using ChatbotBuilderApi.Application.Graphs.Shared.Data;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Meta;

namespace ChatbotBuilderApi.Application.Graphs.Ports.OutputPorts;

public sealed record OutputPortDto(
    InfoMeta Info,
    VisualMeta Visual,
    int NodeIdentifier,
    DataType DataType);