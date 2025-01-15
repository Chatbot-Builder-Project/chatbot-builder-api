using ChatbotBuilderApi.Application.Graphs.Nodes;
using ChatbotBuilderApi.Application.Graphs.Nodes.ApiAction;
using ChatbotBuilderApi.Application.Graphs.Nodes.Generation;
using ChatbotBuilderApi.Application.Graphs.Nodes.Interaction;
using ChatbotBuilderApi.Application.Graphs.Nodes.Prompt;
using ChatbotBuilderApi.Application.Graphs.Nodes.Static;
using ChatbotBuilderApi.Application.Graphs.Nodes.Switch;
using ChatbotBuilderApi.Application.Graphs.Nodes.Switch.Smart;
using ChatbotBuilderApi.Presentation.Graphs.Nodes.ApiAction;
using ChatbotBuilderApi.Presentation.Graphs.Nodes.Generation;
using ChatbotBuilderApi.Presentation.Graphs.Nodes.Interaction;
using ChatbotBuilderApi.Presentation.Graphs.Nodes.Prompt;
using ChatbotBuilderApi.Presentation.Graphs.Nodes.Static;
using ChatbotBuilderApi.Presentation.Graphs.Nodes.Switch;
using Riok.Mapperly.Abstractions;

namespace ChatbotBuilderApi.Presentation.Graphs.Nodes;

[Mapper]
public static partial class NodeMapper
{
    public static NodeModel MapToModel(this NodeDto dto)
    {
        return dto switch
        {
            StaticNodeDto staticNodeDto => staticNodeDto.ToModel(),
            InteractionNodeDto interactionNodeDto => interactionNodeDto.ToModel(),
            SwitchNodeDto switchNodeDto => switchNodeDto.ToModel(),
            PromptNodeDto promptNodeDto => promptNodeDto.ToModel(),
            ApiActionNodeDto apiActionNodeDto => apiActionNodeDto.ToModel(),
            GenerationNodeDto generationNodeDto => generationNodeDto.ToModel(),
            SmartSwitchNodeDto smartSwitchNodeDto => smartSwitchNodeDto.ToModel(),
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
            ApiActionNodeModel apiActionNodeModel => apiActionNodeModel.ToDto(),
            GenerationNodeModel generationNodeModel => generationNodeModel.ToDto(),
            SmartSwitchNodeModel smartSwitchNodeModel => smartSwitchNodeModel.ToDto(),
            _ => throw new ArgumentOutOfRangeException(nameof(model))
        };
    }
}