using ChatbotBuilderApi.Application.Graphs.Shared.Data;
using ChatbotBuilderApi.Presentation.Graphs.Metas;

namespace ChatbotBuilderApi.Presentation.Graphs.Ports;

/// <summary>
/// Input port of a node.
/// </summary>
/// <param name="Info">Generic information for the port.</param>
/// <param name="Visual">Visual information for the port.</param>
/// <param name="NodeId">ID of the node the port belongs to.</param>
/// <param name="DataType">Data type of the port.</param>
public sealed record InputPortModel(
    InfoMetaModel Info,
    VisualMetaModel? Visual,
    int NodeId,
    DataType DataType);