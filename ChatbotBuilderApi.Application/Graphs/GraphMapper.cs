using ChatbotBuilderApi.Application.Graphs.Enums;
using ChatbotBuilderApi.Application.Graphs.Links.DataLinks;
using ChatbotBuilderApi.Application.Graphs.Links.FlowLinks;
using ChatbotBuilderApi.Application.Graphs.Nodes;
using ChatbotBuilderApi.Application.Graphs.Nodes.ApiAction;
using ChatbotBuilderApi.Application.Graphs.Nodes.Interaction;
using ChatbotBuilderApi.Application.Graphs.Nodes.Prompt;
using ChatbotBuilderApi.Application.Graphs.Nodes.Static;
using ChatbotBuilderApi.Application.Graphs.Nodes.Switch;
using ChatbotBuilderApi.Application.Graphs.Shared.Data;
using ChatbotBuilderApi.Application.Graphs.Shared.Data.Extensions;
using ChatbotBuilderApi.Domain.Graphs;
using ChatbotBuilderApi.Domain.Graphs.Abstract;
using ChatbotBuilderApi.Domain.Graphs.Abstract.Behaviors;
using ChatbotBuilderApi.Domain.Graphs.Entities.Links;
using ChatbotBuilderApi.Domain.Graphs.Entities.Nodes;
using ChatbotBuilderApi.Domain.Graphs.Entities.Nodes.Prompt;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Data;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Ids;
using Riok.Mapperly.Abstractions;

namespace ChatbotBuilderApi.Application.Graphs;

[Mapper]
public static partial class GraphMapper
{
    public static Graph ToDomain(this GraphDto dto)
    {
        var enums = dto.Enums
            .Select(e => e.ToDomain())
            .ToList();

        var enumByIdentifier = enums.ToDictionary(e => e.Info.Identifier);

        var flowLinkIdByIdentifier = dto.FlowLinks.ToDictionary(
            fl => fl.Info.Identifier,
            _ => new FlowLinkId(Guid.NewGuid()));

        var nodes = dto.Nodes
            .Select(node =>
            {
                switch (node)
                {
                    case InteractionNodeDto interactionNode:
                        var enumId = interactionNode.OutputEnumIdentifier;
                        var @enum = enumId is null ? null : enumByIdentifier[enumId.Value];
                        return interactionNode.ToDomain(@enum);

                    case StaticNodeDto staticNode:
                    {
                        var dataType = staticNode.Data.ToDataType();
                        return dataType switch
                        {
                            DataType.Text => staticNode.ToDomain<TextData>() as Node,
                            DataType.Option => staticNode.ToDomain<OptionData>(),
                            DataType.Image => staticNode.ToDomain<ImageData>(),
                            _ => throw new ArgumentOutOfRangeException(nameof(dataType))
                        };
                    }

                    case PromptNodeDto promptNode:
                        return promptNode.ToDomain();

                    case SwitchNodeDto switchNode:
                        return switchNode.ToDomain(
                            enumByIdentifier[switchNode.EnumIdentifier],
                            switchNode.Bindings.ToDictionary(
                                b => b.Key,
                                b => flowLinkIdByIdentifier[b.Value]));

                    case ApiActionNodeDto apiActionNode:
                        return apiActionNode.ToDomain();

                    default:
                        throw new ArgumentOutOfRangeException(nameof(node));
                }
            })
            .ToList();

        var inputPorts = new List<Port<InputPortId>>();
        var outputPorts = new List<Port<OutputPortId>>();

        foreach (var node in nodes)
        {
            if (node is IInputNode inputNode)
            {
                inputPorts.AddRange(inputNode.GetInputPorts());
            }

            if (node is IOutputNode outputNode)
            {
                outputPorts.AddRange(outputNode.GetOutputPorts());
            }
        }

        var inputPortIdentifierById = inputPorts.ToDictionary(
            ip => ip.Info.Identifier,
            ip => ip.Id);

        var outputPortIdentifierById = outputPorts.ToDictionary(
            op => op.Info.Identifier,
            op => op.Id);

        var dataLinks = dto.DataLinks
            .Select(dl => DataLink.Create(
                new DataLinkId(Guid.NewGuid()),
                dl.Info,
                dl.Visual,
                inputPortIdentifierById[dl.TargetPortIdentifier],
                outputPortIdentifierById[dl.SourcePortIdentifier]))
            .ToList();

        var nodeIdByIdentifier = nodes.ToDictionary(
            n => n.Info.Identifier,
            n => n.Id);

        var flowLinks = dto.FlowLinks
            .Select(fl => FlowLink.Create(
                flowLinkIdByIdentifier[fl.Info.Identifier],
                fl.Info,
                fl.Visual,
                nodeIdByIdentifier[fl.SourceNodeIdentifier],
                nodeIdByIdentifier[fl.TargetNodeIdentifier]))
            .ToList();

        return Graph.Create(
            new GraphId(Guid.NewGuid()),
            enums,
            inputPorts,
            outputPorts,
            nodes,
            nodeIdByIdentifier[dto.StartNodeIdentifier],
            dataLinks,
            flowLinks);
    }

    public static GraphDto ToDto(this Graph domain)
    {
        var enums = domain.Enums
            .Select(e => e.ToDto())
            .ToList();

        var flowLinkIdentifierById = domain.FlowLinks.ToDictionary(
            fl => fl.Id,
            fl => fl.Info.Identifier);

        var nodes = domain.Nodes
            .Select(NodeDto (node) =>
            {
                return node switch
                {
                    InteractionNode interactionNode => interactionNode.ToDto(),
                    StaticNode<TextData> staticNode => staticNode.ToDto(),
                    StaticNode<OptionData> staticNode => staticNode.ToDto(),
                    StaticNode<ImageData> staticNode => staticNode.ToDto(),
                    PromptNode promptNode => promptNode.ToDto(),
                    SwitchNode switchNode => switchNode.ToDto(switchNode.Bindings.ToDictionary(
                        b => b.Key,
                        b => flowLinkIdentifierById[b.Value])),
                    ApiActionNode apiActionNode => apiActionNode.ToDto(),
                    _ => throw new ArgumentOutOfRangeException(nameof(node))
                };
            })
            .ToList();

        var nodeIdentifierById = domain.Nodes.ToDictionary(
            n => n.Id,
            n => n.Info.Identifier);

        var inputPortIdentifierById = domain.InputPorts.ToDictionary(
            ip => ip.Id,
            ip => ip.Info.Identifier);

        var outputPortIdentifierById = domain.OutputPorts.ToDictionary(
            op => op.Id,
            op => op.Info.Identifier);

        var dataLinks = domain.DataLinks
            .Select(dl => new DataLinkDto(
                dl.Info,
                dl.Visual,
                outputPortIdentifierById[dl.SourcePortId],
                inputPortIdentifierById[dl.TargetPortId]))
            .ToList();

        var flowLinks = domain.FlowLinks
            .Select(fl => new FlowLinkDto(
                fl.Info,
                fl.Visual,
                nodeIdentifierById[fl.SourceNodeId],
                nodeIdentifierById[fl.TargetNodeId]))
            .ToList();

        return new GraphDto(
            nodeIdentifierById[domain.StartNodeId],
            nodes,
            dataLinks,
            flowLinks,
            enums);
    }
}