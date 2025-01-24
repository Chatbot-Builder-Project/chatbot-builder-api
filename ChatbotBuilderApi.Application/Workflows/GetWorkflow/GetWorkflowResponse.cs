using ChatbotBuilderApi.Application.Graphs;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Meta;
using ChatbotBuilderApi.Domain.Users;
using ChatbotBuilderApi.Domain.Workflows;

namespace ChatbotBuilderApi.Application.Workflows.GetWorkflow;

public sealed record GetWorkflowResponse(
    WorkflowId Id,
    UserId OwnerId,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    string Name,
    string Description,
    GraphDto Graph,
    VisualMeta Visual);