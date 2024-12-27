using ChatbotBuilderApi.Application.Core.Shared;

namespace ChatbotBuilderApi.Presentation.Workflows.QueryParams;

public class WorkflowListQueryParams
{
    public required PageParams PageParams { get; set; }

    /// <summary>
    /// Search term to filter workflows by name or description.
    /// </summary>
    public string? Search { get; set; }
}