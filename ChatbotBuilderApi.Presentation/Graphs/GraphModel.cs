using ChatbotBuilderApi.Presentation.Graphs.Links;
using ChatbotBuilderApi.Presentation.Graphs.Nodes;

namespace ChatbotBuilderApi.Presentation.Graphs;

public sealed record GraphModel(
    int StartNodeId,
    IReadOnlyList<NodeModel> Nodes,
    IReadOnlyList<DataLinkModel> DataLinks,
    IReadOnlyList<FlowLinkModel> FlowLinks,
    IReadOnlyList<EnumModel> Enums);