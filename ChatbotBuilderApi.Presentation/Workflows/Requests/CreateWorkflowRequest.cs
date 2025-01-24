using ChatbotBuilderApi.Presentation.Graphs;
using ChatbotBuilderApi.Presentation.Graphs.Metas;

namespace ChatbotBuilderApi.Presentation.Workflows.Requests;

/// <summary>
/// Create workflow request.
/// </summary>
/// <param name="Name">Name of the workflow.</param>
/// <param name="Description">Description of the workflow.</param>
/// <param name="Graph">Graph model of the workflow. Fully created and validated.
/// Otherwise, the workflow creation will fail.</param>
/// <param name="Visual">Generic visual metadata of the workflow.</param>
public sealed record CreateWorkflowRequest(
    string Name,
    string Description,
    GraphModel Graph,
    VisualMetaModel Visual);