using ChatbotBuilderApi.Application.Graphs.Nodes.ApiAction;
using ChatbotBuilderApi.Application.Graphs.Nodes.Interaction;
using ChatbotBuilderApi.Application.Graphs.Nodes.Prompt;
using ChatbotBuilderApi.Application.Graphs.Nodes.Static;
using ChatbotBuilderApi.Application.Graphs.Nodes.Switch;
using FluentValidation;

namespace ChatbotBuilderApi.Application.Graphs.Nodes.Extensions;

public static class NodeExtensions
{
    public static AbstractValidator<TNode> GetValidator<TNode>(this TNode node)
        where TNode : NodeDto
    {
        return node switch
        {
            InteractionNodeDto interactionNode => new InteractionNodeValidator() as AbstractValidator<TNode>,
            StaticNodeDto staticNode => new StaticNodeValidator() as AbstractValidator<TNode>,
            PromptNodeDto promptNode => new PromptNodeValidator() as AbstractValidator<TNode>,
            SwitchNodeDto switchNode => new SwitchNodeValidator() as AbstractValidator<TNode>,
            ApiActionNodeDto apiActionNode => new ApiActionNodeValidator() as AbstractValidator<TNode>,
            _ => throw new ArgumentOutOfRangeException(nameof(node))!
        };
    }
}