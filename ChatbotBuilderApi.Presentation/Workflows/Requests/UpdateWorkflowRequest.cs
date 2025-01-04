using ChatbotBuilderApi.Presentation.Graphs;

namespace ChatbotBuilderApi.Presentation.Workflows.Requests;

/// <summary>
/// Update workflow request.
/// </summary>
/// <param name="Name">Name of the workflow.</param>
/// <param name="Description">Description of the workflow.</param>
/// <param name="Graph">Graph model of the workflow. Fully created and validated.
/// Otherwise, the workflow update will fail.</param>
public sealed record UpdateWorkflowRequest(
    string Name,
    string Description,
    GraphModel Graph);