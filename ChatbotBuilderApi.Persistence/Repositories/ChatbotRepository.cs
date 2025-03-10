using ChatbotBuilderApi.Application.Chatbots;
using ChatbotBuilderApi.Application.Chatbots.GetChatbot;
using ChatbotBuilderApi.Application.Chatbots.ListChatbots;
using ChatbotBuilderApi.Application.Core.Shared.Responses;
using ChatbotBuilderApi.Domain.Chatbots;
using ChatbotBuilderApi.Domain.Chatbots.ValueObjects;
using ChatbotBuilderApi.Domain.Conversations;
using ChatbotBuilderApi.Domain.Graphs;
using ChatbotBuilderApi.Domain.Users;
using ChatbotBuilderApi.Domain.Workflows;
using ChatbotBuilderApi.Persistence.Repositories.Extensions;
using Microsoft.EntityFrameworkCore;
using Version = ChatbotBuilderApi.Domain.Chatbots.ValueObjects.Version;

namespace ChatbotBuilderApi.Persistence.Repositories;

public sealed class ChatbotRepository : CudRepository<Chatbot>, IChatbotRepository
{
    public ChatbotRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<Chatbot?> GetByIdAsync(ChatbotId id, CancellationToken cancellationToken)
    {
        return await Context.Set<Chatbot>()
            .Where(c => c.Id == id)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<Chatbot?> GetByIdAndOwnerAsync(
        ChatbotId id,
        UserId ownerId,
        CancellationToken cancellationToken)
    {
        return await Context.Set<Chatbot>()
            .Where(c =>
                c.Id == id &&
                Context.Set<Workflow>()
                    .First(w => w.Id == c.WorkflowId)
                    .OwnerId == ownerId)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<UserId?> GetOwnerIdAsync(ChatbotId id, CancellationToken cancellationToken)
    {
        return await Context.Set<Chatbot>()
            .Where(c => c.Id == id)
            .Select(c => Context.Set<Workflow>()
                .First(w => w.Id == c.WorkflowId)
                .OwnerId)
            .Select(oid => new UserId(oid))
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<Version?> GetLatestVersionAsync(WorkflowId id, bool isPublic, CancellationToken cancellationToken)
    {
        return await Context.Set<Chatbot>()
            .Where(c => c.WorkflowId == id && c.IsPublic == isPublic)
            .Select(c => c.Version)
            .OrderByDescending(v => v.Major)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<PageResponse<ListChatbotsResponseItem>> ListByQueryAsync(
        ListChatbotsQuery query,
        CancellationToken cancellationToken)
    {
        return await Context.Set<Chatbot>()
            .Where(c =>
                query.Search == null ||
                c.Name.Contains(query.Search) ||
                c.Description.Contains(query.Search))
            .Where(c =>
                !query.IncludeOnlyPersonal ||
                Context.Set<Workflow>()
                    .First(w => w.Id == c.WorkflowId)
                    .OwnerId == query.UserId)
            .Where(c =>
                !query.IncludeOnlyLatest ||
                c.Version == Context.Set<Chatbot>()
                    .Where(c2 => c2.WorkflowId == c.WorkflowId && c2.IsPublic == c.IsPublic)
                    .Select(c2 => c2.Version)
                    .OrderByDescending(v => v.Major)
                    .FirstOrDefault())
            .Where(c =>
                query.WorkflowId == null ||
                c.WorkflowId == query.WorkflowId)
            .OrderByDescending(c => c.CreatedAt)
            .Select(c => new ListChatbotsResponseItem(
                c.Id,
                new UserId(Context.Set<Workflow>()
                    .First(w => w.Id == c.WorkflowId)
                    .OwnerId),
                c.CreatedAt,
                c.UpdatedAt,
                c.Name,
                c.Description,
                c.IsPublic,
                c.Visual,
                c.AvatarImageData))
            .PageResponseAsync(
                query.PageParams,
                cancellationToken);
    }

    public async Task<List<ChatbotId>> ListByWorkflowIdAsync(
        WorkflowId workflowId,
        CancellationToken cancellationToken)
    {
        return await Context.Set<Chatbot>()
            .Where(c => c.WorkflowId == workflowId)
            .OrderByDescending(c => c.CreatedAt)
            .Select(c => c.Id)
            .ToListAsync(cancellationToken);
    }

    public async Task<Graph?> GetGraphAsync(
        ChatbotId chatbotId,
        CancellationToken cancellationToken)
    {
        return await Context.Set<Chatbot>()
            .AsSplitQuery()
            .Where(c => c.Id == chatbotId)
            .Select(c => c.Graph)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<GetChatbotResponseStats?> GetStatsAsync(
        ChatbotId chatbotId,
        CancellationToken cancellationToken)
    {
        const string query = """
                             SELECT 
                                 COUNT(DISTINCT c.OwnerId) AS NumberOfUsers,
                                 COUNT(DISTINCT c.Id) AS NumberOfConversations,
                                 COUNT(im.Id) AS NumberOfMessages
                             FROM Conversation c
                             LEFT JOIN InputMessage im ON c.Id = im.ConversationId
                             WHERE c.ChatbotId = {0}
                             """;

        return await Context.Database
            .SqlQueryRaw<GetChatbotResponseStats>(query, chatbotId.Value)
            .FirstOrDefaultAsync(cancellationToken);
    }
}