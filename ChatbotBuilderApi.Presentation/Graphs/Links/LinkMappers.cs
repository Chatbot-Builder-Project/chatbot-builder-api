using ChatbotBuilderApi.Application.Graphs.Links.DataLinks;
using ChatbotBuilderApi.Application.Graphs.Links.FlowLinks;
using ChatbotBuilderApi.Presentation.Graphs.Metas;
using Riok.Mapperly.Abstractions;

namespace ChatbotBuilderApi.Presentation.Graphs.Links;

[Mapper]
public static partial class LinkMappers
{
    public static DataLinkModel ToModel(this DataLinkDto dto)
    {
        return new DataLinkModel(
            dto.Info.ToModel(),
            dto.Visual.ToModel(),
            dto.InputPortIdentifier,
            dto.OutputPortIdentifier);
    }

    public static DataLinkDto ToDto(this DataLinkModel model)
    {
        return new DataLinkDto(
            model.Info.ToDomain(),
            model.Visual.ToDomain(),
            model.InputPortId,
            model.OutputPortId);
    }

    public static FlowLinkModel ToModel(this FlowLinkDto dto)
    {
        return new FlowLinkModel(
            dto.Info.ToModel(),
            dto.Visual.ToModel(),
            dto.InputNodeIdentifier,
            dto.OutputNodeIdentifier);
    }

    public static FlowLinkDto ToDto(this FlowLinkModel model)
    {
        return new FlowLinkDto(
            model.Info.ToDomain(),
            model.Visual.ToDomain(),
            model.InputNodeId,
            model.OutputNodeId);
    }
}