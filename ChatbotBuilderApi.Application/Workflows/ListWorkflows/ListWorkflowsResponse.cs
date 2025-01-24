using ChatbotBuilderApi.Application.Core.Shared.Responses;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Meta;
using ChatbotBuilderApi.Domain.Users;
using ChatbotBuilderApi.Domain.Workflows;

namespace ChatbotBuilderApi.Application.Workflows.ListWorkflows;

public sealed record ListWorkflowsResponse(PageResponse<ListWorkflowsResponseItem> Page);

public sealed record ListWorkflowsResponseItem(
    WorkflowId Id,
    UserId OwnerId,
    string Name,
    string Description,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    VisualMeta Visual);