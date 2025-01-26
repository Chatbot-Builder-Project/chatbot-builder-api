namespace ChatbotBuilderApi.Presentation.Workflows.QueryParams;

/// <summary>
/// Query parameters for the workflow endpoint
/// </summary>
/// <param name="IncludeStats">Whether to include the stats.</param>
public sealed record WorkflowQueryParams(
    bool IncludeStats = false);