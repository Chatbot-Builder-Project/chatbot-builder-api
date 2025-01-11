using ChatbotBuilderApi.Application.Graphs.Nodes.Switch.Smart;
using ChatbotBuilderApi.Presentation.Graphs.Data;
using ChatbotBuilderApi.Presentation.Graphs.Metas;
using ChatbotBuilderApi.Presentation.Graphs.Ports;
using Riok.Mapperly.Abstractions;

namespace ChatbotBuilderApi.Presentation.Graphs.Nodes.Switch;

[Mapper]
public static partial class SmartSwitchNodeMapper
{
    public static SmartSwitchNodeModel ToModel(this SmartSwitchNodeDto dto)
    {
        return new SmartSwitchNodeModel(
            dto.Info.ToModel(),
            dto.Visual.ToModel(),
            dto.InputPort.ToModel(),
            dto.EnumIdentifier,
            dto.Bindings.ToDictionary(
                kvp => kvp.Key.Value,
                kvp => kvp.Value),
            dto.FallbackFlowLinkId);
    }

    public static SmartSwitchNodeDto ToDto(this SmartSwitchNodeModel model)
    {
        return new SmartSwitchNodeDto(
            model.Info.ToDomain(),
            model.Visual.ToDomain(),
            model.InputPort.ToDto(),
            model.EnumId,
            model.OptionFlowLinkIds.ToDictionary(
                kvp => new OptionDataModel(kvp.Key).ToDomain(),
                kvp => kvp.Value),
            model.FallbackFlowLinkId);
    }
}