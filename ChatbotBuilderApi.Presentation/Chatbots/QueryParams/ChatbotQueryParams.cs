namespace ChatbotBuilderApi.Presentation.Chatbots.QueryParams;

/// <summary>
/// Query parameters for the chatbot endpoint
/// </summary>
/// <param name="IncludeGraphForAdmin">Whether to include the graph.
/// (Works only for the owner of the chatbot)</param>
/// <param name="IncludeStatsForAdmin">Whether to include the stats.
/// (Works only for the owner of the chatbot)</param>
public sealed record ChatbotQueryParams(
    bool IncludeGraphForAdmin = false,
    bool IncludeStatsForAdmin = false);