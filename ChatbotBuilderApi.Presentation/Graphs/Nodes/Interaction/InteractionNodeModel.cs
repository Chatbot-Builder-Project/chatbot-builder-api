using ChatbotBuilderApi.Application.Graphs.Nodes;
using ChatbotBuilderApi.Presentation.Graphs.Metas;
using ChatbotBuilderApi.Presentation.Graphs.Ports;

namespace ChatbotBuilderApi.Presentation.Graphs.Nodes.Interaction;

/// <param name="Info"></param>
/// <param name="Visual"></param>
/// <param name="TextInputPort"></param>
/// <param name="TextOutputPort"></param>
/// <param name="OutputEnumId"></param>
/// <param name="OptionOutputPort"></param>
/// <param name="OutputOptionMetas">Map of each option string to its Metadata</param>
public sealed record InteractionNodeModel(
    InfoMetaModel Info,
    VisualMetaModel Visual,
    InputPortModel? TextInputPort,
    OutputPortModel? TextOutputPort,
    int? OutputEnumId,
    OutputPortModel? OptionOutputPort,
    IReadOnlyDictionary<string, InteractionOptionMetaModel>? OutputOptionMetas)
    : NodeModel(Info, Visual, NodeType.Interaction);

public sealed record InteractionOptionMetaModel(string Description);