using ChatbotBuilderApi.Application.Shared;

namespace ChatbotBuilderApi.Presentation.Features.Workflows.ViewModels;

public class WorkflowListViewModel
{
    public required PageResponse<WorkflowViewModel> Workflows { get; set; }
}