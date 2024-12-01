using ChatbotBuilderApi.Presentation.Features.Shared.Dtos.Workflows;

namespace ChatbotBuilderApi.Presentation.Features.Workflows.ViewModels;

public class WorkflowDetailsViewModel : WorkflowViewModel
{
    public required WorkflowComponentsDto Components { get; set; }
}