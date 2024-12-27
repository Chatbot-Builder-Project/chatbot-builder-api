using ChatbotBuilderApi.Application.Core.Shared.Responses;

namespace ChatbotBuilderApi.Presentation.Workflows.ViewModels;

public sealed record WorkflowListViewModel(PageResponse<WorkflowListViewModelItem> Page);

public sealed record WorkflowListViewModelItem(
    Guid Id,
    Guid OwnerId,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    string Name,
    string Description);