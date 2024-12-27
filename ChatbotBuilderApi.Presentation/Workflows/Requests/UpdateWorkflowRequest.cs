using ChatbotBuilderApi.Presentation.Graphs;

namespace ChatbotBuilderApi.Presentation.Workflows.Requests;

public sealed record UpdateWorkflowRequest(
    string Name,
    string Description,
    GraphModel Graph);