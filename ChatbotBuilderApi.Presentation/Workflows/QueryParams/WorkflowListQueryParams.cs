using ChatbotBuilderApi.Application.Core.Shared;

namespace ChatbotBuilderApi.Presentation.Workflows.QueryParams;

/// <summary>
/// Query parameters for the list of workflows.
/// </summary>
/// <param name="PageParams">Page parameters for the list of workflows.</param>
/// <param name="Search">Only workflows with names or descriptions containing this string will be returned.</param>
public sealed record WorkflowListQueryParams(
    PageParams PageParams,
    string? Search);