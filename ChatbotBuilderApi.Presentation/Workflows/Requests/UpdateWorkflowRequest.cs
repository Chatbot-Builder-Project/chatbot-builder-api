using ChatbotBuilderApi.Presentation.Shared.Dtos.Workflows;

namespace ChatbotBuilderApi.Presentation.Workflows.Requests;

public class UpdateWorkflowRequest
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public required WorkflowComponentsDto Components { get; set; }
}