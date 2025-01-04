namespace ChatbotBuilderApi.Presentation.Graphs.Metas;

/// <summary>
/// Generic visual information for a component in the graph.
/// Not all components have visual information.
/// </summary>
/// <param name="X"></param>
/// <param name="Y"></param>
public sealed record VisualMetaModel(float X, float Y);