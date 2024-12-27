using ChatbotBuilderApi.Application.Core.Shared;

namespace ChatbotBuilderApi.Presentation.Workflows.QueryParams;

public sealed record WorkflowListQueryParams(
    PageParams PageParams,
    string? Search);