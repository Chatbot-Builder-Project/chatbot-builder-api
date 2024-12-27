using ChatbotBuilderApi.Presentation.Graphs;

namespace ChatbotBuilderApi.Presentation.Workflows.Requests;

public sealed record CreateWorkflowRequest(
    string Name,
    string Description,
    GraphModel Graph);