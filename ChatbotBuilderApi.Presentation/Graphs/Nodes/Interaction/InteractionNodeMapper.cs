﻿using ChatbotBuilderApi.Application.Graphs.Nodes.Interaction;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Interactions;
using ChatbotBuilderApi.Presentation.Graphs.Data;
using ChatbotBuilderApi.Presentation.Graphs.Metas;
using ChatbotBuilderApi.Presentation.Graphs.Ports;
using Riok.Mapperly.Abstractions;

namespace ChatbotBuilderApi.Presentation.Graphs.Nodes.Interaction;

[Mapper]
public static partial class InteractionNodeMapper
{
    public static InteractionNodeModel ToModel(this InteractionNodeDto dto)
    {
        return new InteractionNodeModel(
            dto.Info.ToModel(),
            dto.Visual.ToModel(),
            dto.TextInputPort?.ToModel(),
            dto.ImageInputPorts.Select(i => i.ToModel()).ToList(),
            dto.TextOutputPort?.ToModel(),
            dto.OutputEnumIdentifier,
            dto.OptionOutputPort?.ToModel(),
            dto.OutputOptionMetas?.ToDictionary(
                kvp => kvp.Key.Value,
                kvp => new InteractionOptionMetaModel(
                    kvp.Value.Description,
                    kvp.Value.ImageData?.ToModel())));
    }

    public static InteractionNodeDto ToDto(this InteractionNodeModel model)
    {
        return new InteractionNodeDto(
            model.Info.ToDomain(),
            model.Visual.ToDomain(),
            model.TextInputPort?.ToDto(),
            model.ImageInputPorts.Select(i => i.ToDto()).ToList(),
            model.TextOutputPort?.ToDto(),
            model.OutputEnumId,
            model.OptionOutputPort?.ToDto(),
            model.OutputOptionMetas?.ToDictionary(
                kvp => new OptionDataModel(kvp.Key).ToDomain(),
                kvp => InteractionOptionMeta.Create(
                    kvp.Value.Description,
                    kvp.Value.ImageData?.ToDomain())));
    }
}