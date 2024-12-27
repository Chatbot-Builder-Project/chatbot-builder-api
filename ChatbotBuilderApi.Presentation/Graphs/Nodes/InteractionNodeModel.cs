using ChatbotBuilderApi.Application.Graphs.Nodes;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Interactions;
using ChatbotBuilderApi.Presentation.Graphs.Data;
using ChatbotBuilderApi.Presentation.Graphs.Metas;
using ChatbotBuilderApi.Presentation.Graphs.Ports;

namespace ChatbotBuilderApi.Presentation.Graphs.Nodes;

public sealed record InteractionNodeModel(
    InfoMetaModel Info,
    VisualMetaModel Visual,
    InputPortModel? TextInputPort,
    OutputPortModel? TextOutputPort,
    int? OutputEnumId,
    OutputPortModel? OptionOutputPort,
    IReadOnlyDictionary<OptionDataModel, InteractionOptionMeta>? OutputOptionMetas)
    : NodeModel(Info, Visual, NodeType.Interaction);