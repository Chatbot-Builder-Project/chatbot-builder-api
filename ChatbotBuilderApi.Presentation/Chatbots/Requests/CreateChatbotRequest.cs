namespace ChatbotBuilderApi.Presentation.Chatbots.Requests;

public class CreateChatbotRequest
{
    /// <summary>
    /// The workflow id that the chatbot is based on, owned by the user
    /// </summary>
    public Guid WorkflowId { get; set; }

    /// <summary>
    /// Whether the chatbot should be created public or private
    /// </summary>
    public bool IsPublic { get; set; }
}