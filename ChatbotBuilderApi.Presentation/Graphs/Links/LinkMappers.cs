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
            dto.SourcePortIdentifier,
            dto.TargetPortIdentifier);
    }

    public static DataLinkDto ToDto(this DataLinkModel model)
    {
        return new DataLinkDto(
            model.Info.ToDomain(),
            model.Visual.ToDomain(),
            model.SourcePortId,
            model.TargetPortId);
    }

    public static FlowLinkModel ToModel(this FlowLinkDto dto)
    {
        return new FlowLinkModel(
            dto.Info.ToModel(),
            dto.Visual.ToModel(),
            dto.SourceNodeIdentifier,
            dto.TargetNodeIdentifier);
    }

    public static FlowLinkDto ToDto(this FlowLinkModel model)
    {
        return new FlowLinkDto(
            model.Info.ToDomain(),
            model.Visual.ToDomain(),
            model.SourceNodeId,
            model.TargetNodeId);
    }
}