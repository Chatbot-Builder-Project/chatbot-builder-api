using ChatbotBuilderApi.Application.Graphs.Nodes;
using ChatbotBuilderApi.Application.Graphs.Nodes.Interaction;
using ChatbotBuilderApi.Application.Graphs.Nodes.Prompt;
using ChatbotBuilderApi.Application.Graphs.Nodes.Static;
using ChatbotBuilderApi.Application.Graphs.Nodes.Switch;
using ChatbotBuilderApi.Presentation.Graphs.Nodes.Interaction;
using ChatbotBuilderApi.Presentation.Graphs.Nodes.Prompt;
using ChatbotBuilderApi.Presentation.Graphs.Nodes.Static;
using ChatbotBuilderApi.Presentation.Graphs.Nodes.Switch;
using Riok.Mapperly.Abstractions;

namespace ChatbotBuilderApi.Presentation.Graphs.Nodes;

[Mapper]
public static partial class NodeMappers
{
    public static NodeModel MapToModel(this NodeDto dto)
    {
        return dto switch
        {
            StaticNodeDto staticNodeDto => staticNodeDto.ToModel(),
            InteractionNodeDto interactionNodeDto => interactionNodeDto.ToModel(),
            SwitchNodeDto switchNodeDto => switchNodeDto.ToModel(),
            PromptNodeDto promptNodeDto => promptNodeDto.ToModel(),
            _ => throw new ArgumentOutOfRangeException(nameof(dto))
        };
    }

    public static NodeDto MapToDto(this NodeModel model)
    {
        return model switch
        {
            StaticNodeModel staticNodeModel => staticNodeModel.ToDto(),
            InteractionNodeModel interactionNodeModel => interactionNodeModel.ToDto(),
            SwitchNodeModel switchNodeModel => switchNodeModel.ToDto(),
            PromptNodeModel promptNodeModel => promptNodeModel.ToDto(),
            _ => throw new ArgumentOutOfRangeException(nameof(model))
        };
    }
}