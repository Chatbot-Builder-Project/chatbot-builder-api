using ChatbotBuilderApi.Application.Core.Shared;

namespace ChatbotBuilderApi.Presentation.Chatbots.QueryParams;

/// <summary>
/// Query parameters for the list of chatbots.
/// </summary>
/// <param name="PageParams">Page parameters for the list of chatbots.</param>
/// <param name="Search">Only chatbots with names or descriptions containing this string will be returned.</param>
/// <param name="IncludeOnlyPersonal">If true, only chatbots created by the current user are included.</param>
/// <param name="IncludeOnlyLatest">
/// True when you want to list only the latest version of each chatbot.
/// Typically false for example when listing all versions of a chatbot for the user while specifying the WorkflowId.
/// </param>
/// <param name="WorkflowId">
/// Only chatbots that are part of this workflow will be returned.
/// (e.g. to list all versions of a chatbot for one specific workflow).
/// </param>
public sealed record ChatbotListQueryParams(
    PageParams PageParams,
    string? Search,
    bool IncludeOnlyPersonal,
    bool IncludeOnlyLatest,
    Guid? WorkflowId);