using ChatbotBuilderApi.Application.Graphs.Shared.Data;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Meta;

namespace ChatbotBuilderApi.Application.Graphs.Ports.InputPorts;

public sealed record InputPortDto(
    InfoMeta Info,
    VisualMeta Visual,
    PortDirection Direction,
    int NodeIdentifier,
    DataType DataType
) : PortDto(Info, Visual, Direction, NodeIdentifier);