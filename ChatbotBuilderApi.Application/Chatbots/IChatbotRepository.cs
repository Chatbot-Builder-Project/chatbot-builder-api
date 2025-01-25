using ChatbotBuilderApi.Application.Chatbots.ListChatbots;
using ChatbotBuilderApi.Application.Core.Shared.Responses;
using ChatbotBuilderApi.Domain.Chatbots;
using ChatbotBuilderApi.Domain.Chatbots.ValueObjects;
using ChatbotBuilderApi.Domain.Graphs;
using ChatbotBuilderApi.Domain.Users;
using ChatbotBuilderApi.Domain.Workflows;
using Version = ChatbotBuilderApi.Domain.Chatbots.ValueObjects.Version;

namespace ChatbotBuilderApi.Application.Chatbots;

public interface IChatbotRepository
{
    void Add(Chatbot chatbot);
    void Update(Chatbot chatbot);
    void Delete(Chatbot chatbot);

    Task<Chatbot?> GetByIdAsync(
        ChatbotId id,
        CancellationToken cancellationToken);

    Task<Chatbot?> GetByIdAndOwnerAsync(
        ChatbotId id,
        UserId ownerId,
        CancellationToken cancellationToken);

    Task<UserId?> GetOwnerIdAsync(
        ChatbotId id,
        CancellationToken cancellationToken);

    Task<Version?> GetLatestVersionAsync(
        WorkflowId id,
        bool isPublic,
        CancellationToken cancellationToken);

    Task<PageResponse<ListChatbotsResponseItem>> ListByQueryAsync(
        ListChatbotsQuery query,
        CancellationToken cancellationToken);

    Task<List<ChatbotId>> ListByWorkflowIdAsync(
        WorkflowId workflowId,
        CancellationToken cancellationToken);

    /// <remarks>Does not track graph changes</remarks>
    Task<Graph?> GetGraphAsync(
        ChatbotId chatbotId,
        CancellationToken cancellationToken);
}