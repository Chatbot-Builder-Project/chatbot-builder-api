using ChatbotBuilderApi.Presentation.Graphs;

namespace ChatbotBuilderApi.Presentation.Workflows.ViewModels;

public sealed record WorkflowViewModel(
    Guid Id,
    Guid OwnerId,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    string Name,
    string Description,
    GraphModel Graph);