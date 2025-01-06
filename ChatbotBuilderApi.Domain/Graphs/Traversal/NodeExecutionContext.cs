using ChatbotBuilderApi.Domain.Graphs.Nodes.ApiAction;

namespace ChatbotBuilderApi.Domain.Graphs.Traversal;

/// <summary>
/// Contains all needed services for any node to execute.
/// </summary>
public sealed record NodeExecutionContext(
    IApiActionService ApiActionService);