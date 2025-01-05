using ChatbotBuilderApi.Presentation.Graphs.Enums;
using ChatbotBuilderApi.Presentation.Graphs.Links;
using ChatbotBuilderApi.Presentation.Graphs.Nodes;

namespace ChatbotBuilderApi.Presentation.Graphs;

/// <summary>
/// A graph model.
/// These are all the elements that make up a graph.
/// Note that ports are included within the nodes.
/// </summary>
/// <param name="StartNodeId">ID of the start node. Must be an Interaction node.</param>
/// <param name="Nodes">List of nodes in the graph.</param>
/// <param name="DataLinks">List of data links in the graph.</param>
/// <param name="FlowLinks">List of flow links in the graph.</param>
/// <param name="Enums">List of enums in the graph.</param>
public sealed record GraphModel(
    int StartNodeId,
    IReadOnlyList<NodeModel> Nodes,
    IReadOnlyList<DataLinkModel> DataLinks,
    IReadOnlyList<FlowLinkModel> FlowLinks,
    IReadOnlyList<EnumModel> Enums);