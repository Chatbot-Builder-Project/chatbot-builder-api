using ChatbotBuilderApi.Presentation.Features.Shared.Dtos.Workflows.Components.Nodes;
using ChatbotBuilderApi.Presentation.Features.Shared.Dtos.Workflows.Enums;
using JsonSubTypes;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;

namespace ChatbotBuilderApi.Presentation.Features.Shared.Dtos.Workflows.Abstract;

[JsonConverter(typeof(JsonSubtypes), nameof(NodeType))]
[JsonSubtypes.KnownSubType(typeof(StaticNodeDto), NodeType.Static)]
[JsonSubtypes.KnownSubType(typeof(InteractionNodeDto), NodeType.Interaction)]
[JsonSubtypes.KnownSubType(typeof(GroupNodeDto), NodeType.Group)]
[JsonSubtypes.KnownSubType(typeof(SwitchNodeDto), NodeType.Switch)]
[JsonSubtypes.KnownSubType(typeof(SmartSwitchNodeDto), NodeType.SmartSwitch)]
[JsonSubtypes.KnownSubType(typeof(PromptNodeDto), NodeType.Prompt)]
[JsonSubtypes.KnownSubType(typeof(GenerationNodeDto), NodeType.Generation)]
[JsonSubtypes.KnownSubType(typeof(MemoryNodeDto), NodeType.Memory)]
[JsonSubtypes.KnownSubType(typeof(KnowledgeNodeDto), NodeType.Knowledge)]
[JsonSubtypes.KnownSubType(typeof(KnowledgeSearchNodeDto), NodeType.KnowledgeSearch)]
[SwaggerDiscriminator(nameof(NodeType))]
[SwaggerSubType(typeof(StaticNodeDto), DiscriminatorValue = nameof(NodeType.Static))]
[SwaggerSubType(typeof(InteractionNodeDto), DiscriminatorValue = nameof(NodeType.Interaction))]
[SwaggerSubType(typeof(GroupNodeDto), DiscriminatorValue = nameof(NodeType.Group))]
[SwaggerSubType(typeof(SwitchNodeDto), DiscriminatorValue = nameof(NodeType.Switch))]
[SwaggerSubType(typeof(SmartSwitchNodeDto), DiscriminatorValue = nameof(NodeType.SmartSwitch))]
[SwaggerSubType(typeof(PromptNodeDto), DiscriminatorValue = nameof(NodeType.Prompt))]
[SwaggerSubType(typeof(GenerationNodeDto), DiscriminatorValue = nameof(NodeType.Generation))]
[SwaggerSubType(typeof(MemoryNodeDto), DiscriminatorValue = nameof(NodeType.Memory))]
[SwaggerSubType(typeof(KnowledgeNodeDto), DiscriminatorValue = nameof(NodeType.Knowledge))]
[SwaggerSubType(typeof(KnowledgeSearchNodeDto), DiscriminatorValue = nameof(NodeType.KnowledgeSearch))]
public abstract class NodeDto : VisualComponentDto
{
    public NodeType NodeType { get; set; }
}