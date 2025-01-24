using ChatbotBuilderApi.Application.Core.Extensions;
using ChatbotBuilderApi.Application.Graphs.Enums;
using ChatbotBuilderApi.Application.Graphs.Links.DataLinks;
using ChatbotBuilderApi.Application.Graphs.Links.FlowLinks;
using ChatbotBuilderApi.Application.Graphs.Nodes;
using ChatbotBuilderApi.Application.Graphs.Nodes.Abstract;
using ChatbotBuilderApi.Application.Graphs.Nodes.Extensions;
using ChatbotBuilderApi.Application.Graphs.Shared.Metas;
using FluentValidation;

namespace ChatbotBuilderApi.Application.Graphs;

public sealed class GraphValidator : AbstractValidator<GraphDto>
{
    public GraphValidator()
    {
        RuleFor(x => x.Visual)
            .SetValidator(new VisualMetaValidator());

        RuleFor(x => x)
            .Must(x =>
            {
                HashSet<int> identifiers = [];

                if (x.Nodes.Any(node => !identifiers.Add(node.Info.Identifier)))
                {
                    return false;
                }

                if (x.DataLinks.Any(link => !identifiers.Add(link.Info.Identifier)))
                {
                    return false;
                }

                if (x.FlowLinks.Any(link => !identifiers.Add(link.Info.Identifier)))
                {
                    return false;
                }

                if (x.Enums.Any(@enum => !identifiers.Add(@enum.Info.Identifier)))
                {
                    return false;
                }

                return true;
            })
            .WithMessage("All identifiers in the graph must be unique.");

        RuleFor(x => x.Nodes)
            .Must(nodes => nodes
                .Any(node => node.Type == NodeType.Interaction))
            .WithMessage("Graph must contain at least one interaction node.");

        RuleFor(x => x.Nodes)
            .MustBeUnique()
            .WithMessage("All nodes in the graph must be unique.");

        RuleForEach(x => x.Nodes)
            .ChildRules(node => node
                .RuleFor(x => x)
                .SetValidator(x => x.GetValidator()));

        RuleFor(x => x.DataLinks)
            .MustBeUnique()
            .WithMessage("All data links in the graph must be unique.");

        RuleForEach(x => x.DataLinks)
            .ChildRules(link => link
                .RuleFor(x => x)
                .SetValidator(new DataLinkValidator()));

        RuleFor(x => x.FlowLinks)
            .MustBeUnique()
            .WithMessage("All flow links in the graph must be unique.");

        RuleForEach(x => x.FlowLinks)
            .ChildRules(link => link
                .RuleFor(x => x)
                .SetValidator(new FlowLinkValidator()));

        RuleFor(x => x.Enums)
            .MustBeUnique()
            .WithMessage("All enums in the graph must be unique.");

        RuleForEach(x => x.Enums)
            .ChildRules(@enum => @enum
                .RuleFor(x => x)
                .SetValidator(new EnumValidator()));

        RuleFor(x => x)
            .Must(x =>
            {
                var enumsByIdentifier = x.Enums.ToDictionary(@enum => @enum.Info.Identifier);
                foreach (var node in x.Nodes)
                {
                    if (node is IEnumNodeDto enumNodeDto
                        && enumNodeDto.GetEnumIds().Any(enumId => !enumsByIdentifier.ContainsKey(enumId)))
                    {
                        return false;
                    }
                }

                return true;
            })
            .WithMessage("Any node that references an enum identifier must have a corresponding enum in the graph.");

        RuleFor(x => x)
            .Must(x =>
            {
                var flowLinksByIdentifier = x.FlowLinks.ToDictionary(link => link.Info.Identifier);
                foreach (var node in x.Nodes)
                {
                    if (node is ISwitchNodeDto switchNodeDto
                        && switchNodeDto.GetFlowLinkIds().Any(portId => !flowLinksByIdentifier.ContainsKey(portId)))
                    {
                        return false;
                    }
                }

                return true;
            })
            .WithMessage("Any switch node that references a flow link identifier" +
                         " must have a corresponding flow link in the graph.");
    }
}