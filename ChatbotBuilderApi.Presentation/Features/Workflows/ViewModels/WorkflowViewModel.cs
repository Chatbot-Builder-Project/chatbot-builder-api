namespace ChatbotBuilderApi.Presentation.Features.Workflows.ViewModels;

public class WorkflowViewModel
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}