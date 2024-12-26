using ChatbotBuilderApi.Application.Core.Abstract.Messaging;
using ChatbotBuilderApi.Application.Core.Shared;

namespace ChatbotBuilderApi.Application.Conversations.ListMessages;

public sealed class ListMessagesQueryHandler : IQueryHandler<ListMessagesQuery, ListMessagesResponse>
{
    private readonly IConversationRepository _repository;

    public ListMessagesQueryHandler(IConversationRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ListMessagesResponse>> Handle(
        ListMessagesQuery request,
        CancellationToken cancellationToken)
    {
        var conversation = await _repository.GetByIdAndUserAsync(
            request.ConversationId,
            request.UserId,
            cancellationToken);

        if (conversation is null)
        {
            return Result.Failure<ListMessagesResponse>(ConversationsApplicationErrors.ConversationNotFound);
        }

        var response = await _repository.ListMessagesAsync(
            request.ConversationId,
            request.PageParams,
            cancellationToken);

        return Result.Success(response);
    }
}