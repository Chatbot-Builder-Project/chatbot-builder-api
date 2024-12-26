using ChatbotBuilderApi.Application.Core.Abstract.Messaging;
using ChatbotBuilderApi.Application.Core.Shared;

namespace ChatbotBuilderApi.Application.Conversations.ListConversations;

public sealed class ListConversationsQueryHandler : IQueryHandler<ListConversationsQuery, ListConversationsResponse>
{
    private readonly IConversationRepository _repository;

    public ListConversationsQueryHandler(IConversationRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ListConversationsResponse>> Handle(
        ListConversationsQuery request,
        CancellationToken cancellationToken)
    {
        var conversations = await _repository.ListByQueryAsync(request, cancellationToken);
        var response = new ListConversationsResponse(conversations);
        return Result.Success(response);
    }
}