using ChatbotBuilderApi.Presentation.Graphs;
using ChatbotBuilderApi.Presentation.Graphs.Metas;

namespace ChatbotBuilderApi.Presentation.Workflows.ViewModels;

/// <summary>
/// A workflow view model.
/// </summary>
/// <param name="Id">ID of the workflow.</param>
/// <param name="OwnerId">ID of the owner of the workflow.</param>
/// <param name="CreatedAt">Date and time the workflow was created.</param>
/// <param name="UpdatedAt">Date and time the workflow was last updated.</param>
/// <param name="Name">Name of the workflow.</param>
/// <param name="Description">Description of the workflow.</param>
/// <param name="Graph">Graph of the workflow.</param>
/// <param name="Visual">Generic visual metadata of the workflow.</param>
public sealed record WorkflowViewModel(
    Guid Id,
    Guid OwnerId,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    string Name,
    string Description,
    GraphModel Graph,
    VisualMetaModel Visual);