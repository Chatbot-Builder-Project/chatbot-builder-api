using ChatbotBuilderApi.Application.Core.Shared;

namespace ChatbotBuilderApi.Presentation.Features.Chatbots.QueryParams;

public class ChatbotListQueryParams
{
    public required PageParams PageParams { get; set; }

    /// <summary>
    /// Search term to filter chatbots by name or description.
    /// </summary>
    public string? Search { get; set; }

    /// <summary>
    /// If true, only the chatbots created by the current user are included.
    /// AdminDetails will be included in the response if and only if this option is selected.
    /// </summary>
    public bool IncludeOnlyPersonal { get; set; }

    /// <summary>
    /// Default is true, so only the latest version of each chatbot is included.
    /// Typically false when listing all versions of a chatbot for the user while specifying the WorkflowId.
    /// </summary>
    public bool IncludeOnlyLatest { get; set; } = true;

    /// <summary>
    /// Limit the results to a specific workflow (e.g. to list all versions of a chatbot for one specific workflow).
    /// </summary>
    public Guid? WorkflowId { get; set; }
}