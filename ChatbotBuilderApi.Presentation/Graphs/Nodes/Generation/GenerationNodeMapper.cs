using ChatbotBuilderApi.Application.Graphs.Nodes.Generation;
using ChatbotBuilderApi.Domain.Graphs.Nodes.Generation;
using ChatbotBuilderApi.Presentation.Graphs.Metas;
using ChatbotBuilderApi.Presentation.Graphs.Ports;
using Riok.Mapperly.Abstractions;

namespace ChatbotBuilderApi.Presentation.Graphs.Nodes.Generation;

[Mapper]
public static partial class GenerationNodeMapper
{
    public static GenerationNodeModel ToModel(GenerationNodeDto dto)
    {
        return new GenerationNodeModel(
            dto.Info.ToModel(),
            dto.Visual.ToModel(),
            dto.InputPort.ToModel(),
            dto.OutputPort.ToModel(),
            new GenerationOptionsModel(
                dto.Options.UseMemory,
                dto.Options.ResponseSchema));
    }

    public static GenerationNodeDto ToDto(GenerationNodeModel model)
    {
        return new GenerationNodeDto(
            model.Info.ToDomain(),
            model.Visual.ToDomain(),
            model.InputPort.ToDto(),
            model.OutputPort.ToDto(),
            GenerationOptions.Create(
                model.Options.UseMemory,
                model.Options.ResponseSchema));
    }
}