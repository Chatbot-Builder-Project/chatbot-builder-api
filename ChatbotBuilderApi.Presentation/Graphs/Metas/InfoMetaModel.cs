namespace ChatbotBuilderApi.Presentation.Graphs.Metas;

/// <summary>
/// Generic information for a component in the graph.
/// </summary>
/// <param name="Id">ID of the component.</param>
/// <param name="Name">Name of the component.</param>
public sealed record InfoMetaModel(int Id, string Name);