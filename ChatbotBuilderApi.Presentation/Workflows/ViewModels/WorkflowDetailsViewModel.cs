using ChatbotBuilderApi.Presentation.Shared.Dtos.Workflows;

namespace ChatbotBuilderApi.Presentation.Workflows.ViewModels;

public class WorkflowDetailsViewModel : WorkflowViewModel
{
    public required WorkflowComponentsDto Components { get; set; }
}