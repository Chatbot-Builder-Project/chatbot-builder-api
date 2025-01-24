using ChatbotBuilderApi.Application.Core.Shared.Responses;
using ChatbotBuilderApi.Presentation.Graphs.Metas;

namespace ChatbotBuilderApi.Presentation.Workflows.ViewModels;

/// <summary>
/// A list of workflows.
/// </summary>
/// <param name="Page">The page of workflows.</param>
public sealed record WorkflowListViewModel(PageResponse<WorkflowListViewModelItem> Page);

/// <summary>
/// Item for the list of workflows view model.
/// </summary>
/// <param name="Id">ID of the workflow.</param>
/// <param name="OwnerId">ID of the owner of the workflow.</param>
/// <param name="CreatedAt">Date and time the workflow was created.</param>
/// <param name="UpdatedAt">Date and time the workflow was last updated.</param>
/// <param name="Name">Name of the workflow.</param>
/// <param name="Description">Description of the workflow.</param>
/// <param name="Visual">Generic visual metadata of the workflow.</param>
public sealed record WorkflowListViewModelItem(
    Guid Id,
    Guid OwnerId,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    string Name,
    string Description,
    VisualMetaModel Visual);