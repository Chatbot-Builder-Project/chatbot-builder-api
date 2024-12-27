using ChatbotBuilderApi.Application.Core.Shared;

namespace ChatbotBuilderApi.Presentation.Chatbots.QueryParams;

/// <param name="PageParams"></param>
/// <param name="Search"></param>
/// <param name="IncludeOnlyPersonal">
/// If true, only the chatbots created by the current user are included.
/// AdminDetails will be included in the response if and only if this option is selected.
/// </param>
/// <param name="IncludeOnlyLatest">
/// Default is true, so only the latest version of each chatbot is included.
/// Typically false when listing all versions of a chatbot for the user while specifying the WorkflowId.
/// </param>
/// <param name="WorkflowId">
/// Limit the results to a specific workflow (e.g. to list all versions of a chatbot for one specific workflow).
/// </param>
public sealed record ChatbotListQueryParams(
    PageParams PageParams,
    string? Search,
    bool IncludeOnlyPersonal,
    bool IncludeOnlyLatest,
    Guid? WorkflowId);