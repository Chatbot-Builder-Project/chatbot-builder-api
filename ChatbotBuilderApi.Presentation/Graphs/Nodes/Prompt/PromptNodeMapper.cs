using ChatbotBuilderApi.Application.Graphs.Nodes.Prompt;
using ChatbotBuilderApi.Presentation.Graphs.Metas;
using ChatbotBuilderApi.Presentation.Graphs.Ports;
using Riok.Mapperly.Abstractions;

namespace ChatbotBuilderApi.Presentation.Graphs.Nodes.Prompt;

[Mapper]
public static partial class PromptNodeMapper
{
    public static PromptNodeModel ToModel(this PromptNodeDto dto)
    {
        return new PromptNodeModel(
            dto.Info.ToModel(),
            dto.Visual.ToModel(),
            dto.Template.Text,
            dto.OutputPort.ToModel(),
            dto.InputPorts.Select(i => i.ToModel()).ToList());
    }

    public static PromptNodeDto ToDto(this PromptNodeModel model)
    {
        return new PromptNodeDto(
            model.Info.ToDomain(),
            model.Visual.ToDomain(),
            new PromptTemplateDto(model.Template),
            model.OutputPort.ToDto(),
            model.InputPorts.Select(i => i.ToDto()).ToList());
    }
}