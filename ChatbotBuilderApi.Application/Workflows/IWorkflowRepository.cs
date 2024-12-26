using ChatbotBuilderApi.Application.Core.Shared.Responses;
using ChatbotBuilderApi.Application.Workflows.ListWorkflows;
using ChatbotBuilderApi.Domain.Users;
using ChatbotBuilderApi.Domain.Workflows;

namespace ChatbotBuilderApi.Application.Workflows;

public interface IWorkflowRepository
{
    void Add(Workflow workflow);
    void Update(Workflow workflow);
    void Delete(Workflow workflow);

    Task<Workflow?> GetByIdAndUserAsync(
        WorkflowId id,
        UserId ownerId,
        bool includeGraph,
        CancellationToken cancellationToken);

    Task<PageResponse<ListWorkflowsResponseItem>> ListByQueryAsync(
        ListWorkflowsQuery query,
        CancellationToken cancellationToken);
}