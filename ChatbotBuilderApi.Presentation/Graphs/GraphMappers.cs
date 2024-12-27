using ChatbotBuilderApi.Application.Graphs;
using ChatbotBuilderApi.Presentation.Graphs.Enums;
using ChatbotBuilderApi.Presentation.Graphs.Links;
using ChatbotBuilderApi.Presentation.Graphs.Nodes;
using Riok.Mapperly.Abstractions;

namespace ChatbotBuilderApi.Presentation.Graphs;

[Mapper]
public static partial class GraphMappers
{
    public static GraphModel ToModel(this GraphDto dto)
    {
        return new GraphModel(
            dto.StartNodeIdentifier,
            dto.Nodes.Select(x => x.MapToModel()).ToList(),
            dto.DataLinks.Select(x => x.ToModel()).ToList(),
            dto.FlowLinks.Select(x => x.ToModel()).ToList(),
            dto.Enums.Select(x => x.ToModel()).ToList());
    }

    public static GraphDto ToDto(this GraphModel model)
    {
        return new GraphDto(
            model.StartNodeId,
            model.Nodes.Select(x => x.MapToDto()).ToList(),
            model.DataLinks.Select(x => x.ToDto()).ToList(),
            model.FlowLinks.Select(x => x.ToDto()).ToList(),
            model.Enums.Select(x => x.ToDto()).ToList());
    }
}