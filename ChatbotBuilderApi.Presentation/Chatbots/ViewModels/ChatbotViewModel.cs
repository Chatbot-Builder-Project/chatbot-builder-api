namespace ChatbotBuilderApi.Presentation.Chatbots.ViewModels;

public class ChatbotViewModel
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public ChatbotAdminDetailsViewModel? AdminDetails { get; set; }
}