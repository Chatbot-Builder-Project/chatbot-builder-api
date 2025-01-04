using ChatbotBuilderApi.Application.Graphs.Nodes;
using ChatbotBuilderApi.Presentation.Graphs.Data;
using ChatbotBuilderApi.Presentation.Graphs.Metas;
using ChatbotBuilderApi.Presentation.Graphs.Ports;

namespace ChatbotBuilderApi.Presentation.Graphs.Nodes.Static;

/// <summary>
/// Static node model.
/// Stores a static value and has an output port with the same data type.
/// </summary>
/// <param name="Info">Generic information for the node.</param>
/// <param name="Visual">Visual information for the node.</param>
/// <param name="Data">Data model containing the static value.</param>
/// <param name="OutputPort">Output port of the node. Must have the same data type as the static value.</param>
public sealed record StaticNodeModel(
    InfoMetaModel Info,
    VisualMetaModel Visual,
    DataModel Data,
    OutputPortModel OutputPort)
    : NodeModel(Info, Visual, NodeType.Static);