using ChatbotBuilderApi.Application.Graphs.Nodes;
using ChatbotBuilderApi.Presentation.Graphs.Metas;
using ChatbotBuilderApi.Presentation.Graphs.Nodes.Interaction;
using ChatbotBuilderApi.Presentation.Graphs.Nodes.Prompt;
using ChatbotBuilderApi.Presentation.Graphs.Nodes.Static;
using ChatbotBuilderApi.Presentation.Graphs.Nodes.Switch;
using JsonSubTypes;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;

namespace ChatbotBuilderApi.Presentation.Graphs.Nodes;

[JsonConverter(typeof(JsonSubtypes), nameof(NodeModel.Type))]
[JsonSubtypes.KnownSubType(typeof(StaticNodeModel), NodeType.Static)]
[JsonSubtypes.KnownSubType(typeof(PromptNodeModel), NodeType.Prompt)]
[JsonSubtypes.KnownSubType(typeof(InteractionNodeModel), NodeType.Interaction)]
[JsonSubtypes.KnownSubType(typeof(SwitchNodeModel), NodeType.Switch)]
[SwaggerDiscriminator(nameof(NodeType))]
[SwaggerSubType(typeof(StaticNodeModel), DiscriminatorValue = nameof(NodeType.Static))]
[SwaggerSubType(typeof(PromptNodeModel), DiscriminatorValue = nameof(NodeType.Prompt))]
[SwaggerSubType(typeof(InteractionNodeModel), DiscriminatorValue = nameof(NodeType.Interaction))]
[SwaggerSubType(typeof(SwitchNodeModel), DiscriminatorValue = nameof(NodeType.Switch))]
public abstract record NodeModel(
    InfoMetaModel Info,
    VisualMetaModel Visual,
    NodeType Type);