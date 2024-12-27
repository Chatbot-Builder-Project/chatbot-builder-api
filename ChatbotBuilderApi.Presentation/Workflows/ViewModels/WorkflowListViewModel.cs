using ChatbotBuilderApi.Application.Core.Shared.Responses;

namespace ChatbotBuilderApi.Presentation.Workflows.ViewModels;

public class WorkflowListViewModel
{
    public required PageResponse<WorkflowViewModel> Workflows { get; set; }
}