﻿using ChatbotBuilderApi.Application.Graphs.Nodes.Switch;
using ChatbotBuilderApi.Presentation.Graphs.Data;
using ChatbotBuilderApi.Presentation.Graphs.Metas;
using ChatbotBuilderApi.Presentation.Graphs.Ports;
using Riok.Mapperly.Abstractions;

namespace ChatbotBuilderApi.Presentation.Graphs.Nodes.Switch;

[Mapper]
public static partial class SwitchNodeMapper
{
    public static SwitchNodeModel ToModel(this SwitchNodeDto dto)
    {
        return new SwitchNodeModel(
            dto.Info.ToModel(),
            dto.Visual.ToModel(),
            dto.InputPort.ToModel(),
            dto.EnumIdentifier,
            dto.Bindings.ToDictionary(
                kvp => kvp.Key.Value,
                kvp => kvp.Value));
    }

    public static SwitchNodeDto ToDto(this SwitchNodeModel model)
    {
        return new SwitchNodeDto(
            model.Info.ToDomain(),
            model.Visual.ToDomain(),
            model.InputPort.ToDto(),
            model.EnumId,
            model.OptionFlowLinkIds.ToDictionary(
                kvp => new OptionDataModel(kvp.Key).ToDomain(),
                kvp => kvp.Value));
    }
}