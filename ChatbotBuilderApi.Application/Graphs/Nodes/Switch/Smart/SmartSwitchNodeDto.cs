using ChatbotBuilderApi.Application.Graphs.Ports.InputPorts;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Data;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Meta;

namespace ChatbotBuilderApi.Application.Graphs.Nodes.Switch.Smart;

public sealed record SmartSwitchNodeDto(
    InfoMeta Info,
    VisualMeta Visual,
    InputPortDto InputPort,
    int EnumIdentifier,
    IReadOnlyDictionary<OptionData, int> Bindings
) : SwitchNodeDtoBase(Info, Visual, InputPort, EnumIdentifier, Bindings);