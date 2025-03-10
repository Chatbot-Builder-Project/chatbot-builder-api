using ChatbotBuilderApi.Application.Core.Shared.Responses;
using ChatbotBuilderApi.Application.Workflows;
using ChatbotBuilderApi.Application.Workflows.GetWorkflow;
using ChatbotBuilderApi.Application.Workflows.ListWorkflows;
using ChatbotBuilderApi.Domain.Graphs;
using ChatbotBuilderApi.Domain.Users;
using ChatbotBuilderApi.Domain.Workflows;
using ChatbotBuilderApi.Persistence.Repositories.Extensions;
using Microsoft.EntityFrameworkCore;

namespace ChatbotBuilderApi.Persistence.Repositories;

public sealed class WorkflowRepository : CudRepository<Workflow>, IWorkflowRepository
{
    public WorkflowRepository(AppDbContext context) : base(context)
    {
    }

    public new void Update(Workflow workflow)
    {
        Context.Set<Graph>().Add(workflow.Graph);
        base.Update(workflow);
    }

    public async Task<Workflow?> GetByIdAndUserAsync(
        WorkflowId id,
        UserId ownerId,
        bool includeGraph,
        CancellationToken cancellationToken)
    {
        var queryable = Context.Set<Workflow>()
            .Where(w =>
                w.Id == id &&
                w.OwnerId == ownerId);

        if (includeGraph)
        {
            queryable = queryable
                .AsSplitQuery()
                .Include(w => w.Graph);
        }

        return await queryable.FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<PageResponse<ListWorkflowsResponseItem>> ListByQueryAsync(
        ListWorkflowsQuery query,
        CancellationToken cancellationToken)
    {
        return await Context.Set<Workflow>()
            .Where(w => w.OwnerId == query.OwnerId)
            .Where(w => query.Search == null
                        || w.Name.Contains(query.Search)
                        || w.Description.Contains(query.Search))
            .OrderByDescending(w => w.CreatedAt)
            .Select(w => new ListWorkflowsResponseItem(
                w.Id,
                new UserId(w.OwnerId),
                w.Name,
                w.Description,
                w.CreatedAt,
                w.UpdatedAt,
                w.Visual))
            .PageResponseAsync(query.PageParams, cancellationToken);
    }

    public async Task<GetWorkflowResponseStats?> GetStatsAsync(
        WorkflowId workflowId,
        CancellationToken cancellationToken)
    {
        const string query = """
                             SELECT 
                                 COUNT(DISTINCT c.OwnerId) AS NumberOfUsers,
                                 COUNT(DISTINCT c.Id) AS NumberOfConversations,
                                 COUNT(im.Id) AS NumberOfMessages,
                                 COUNT(DISTINCT cb.Id) AS NumberOfChatbots
                             FROM Workflow w
                             LEFT JOIN Chatbot cb ON w.Id = cb.WorkflowId
                             LEFT JOIN Conversation c ON cb.Id = c.ChatbotId
                             LEFT JOIN InputMessage im ON c.Id = im.ConversationId
                             WHERE w.Id = {0}
                             """;

        return await Context.Database
            .SqlQueryRaw<GetWorkflowResponseStats>(query, workflowId.Value)
            .FirstOrDefaultAsync(cancellationToken);
    }
}