using ChatbotBuilderApi.Domain.Graphs.Nodes.ApiAction;
using ChatbotBuilderApi.Domain.Graphs.Nodes.Generation;
using ChatbotBuilderApi.Domain.Graphs.Nodes.Switch.Smart;

namespace ChatbotBuilderApi.Domain.Graphs.Traversal;

/// <summary>
/// Contains all needed services for any node to execute.
/// </summary>
public sealed record NodeExecutionContext(
    IApiActionService ApiActionService,
    IGenerationService GenerationService,
    ISmartRoutingService SmartRoutingService);