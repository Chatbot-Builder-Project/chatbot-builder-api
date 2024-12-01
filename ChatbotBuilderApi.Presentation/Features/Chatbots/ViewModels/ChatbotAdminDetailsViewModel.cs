namespace ChatbotBuilderApi.Presentation.Features.Chatbots.ViewModels;

public class ChatbotAdminDetailsViewModel
{
    public Guid WorkflowId { get; set; }
    public int Version { get; set; }
    public bool IsLatest { get; set; }
    public bool IsPublic { get; set; }
}