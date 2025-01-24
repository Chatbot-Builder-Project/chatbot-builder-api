using Newtonsoft.Json.Linq;

namespace ChatbotBuilderApi.Presentation.Graphs.Metas;

/// <summary>
/// Generic visual information for a component in the graph.
/// Not all components have visual information.
/// </summary>
/// <param name="Data">The visual information.
/// This is a dynamic object that can be used to store any visual information.
/// It won't be used by the system, but it can be used by the client to store any visual information.</param>
public sealed record VisualMetaModel(JObject? Data);