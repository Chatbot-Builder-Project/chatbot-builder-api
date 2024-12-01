namespace ChatbotBuilderApi.Presentation.Features.Chatbots.Requests;

public class UpdateChatbotRequest
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool IsPublic { get; set; }
}