using ChatbotBuilderApi.Application.Core.Abstract.Messaging;
using ChatbotBuilderApi.Application.Core.Shared;

namespace ChatbotBuilderApi.Application.Chatbots.ListChatbots;

public sealed class ListChatbotsQueryHandler : IQueryHandler<ListChatbotsQuery, ListChatbotsResponse>
{
    private readonly IChatbotRepository _repository;

    public ListChatbotsQueryHandler(IChatbotRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ListChatbotsResponse>> Handle(
        ListChatbotsQuery request,
        CancellationToken cancellationToken)
    {
        var chatbots = await _repository.ListByQueryAsync(request, cancellationToken);
        return Result.Success(new ListChatbotsResponse(chatbots));
    }
}