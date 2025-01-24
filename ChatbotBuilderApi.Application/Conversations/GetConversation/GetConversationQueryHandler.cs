using ChatbotBuilderApi.Application.Core.Abstract.Messaging;
using ChatbotBuilderApi.Application.Core.Shared;

namespace ChatbotBuilderApi.Application.Conversations.GetConversation;

public sealed class GetConversationQueryHandler : IQueryHandler<GetConversationQuery, GetConversationResponse>
{
    private readonly IConversationRepository _repository;

    public GetConversationQueryHandler(IConversationRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<GetConversationResponse>> Handle(
        GetConversationQuery request,
        CancellationToken cancellationToken)
    {
        var conversation = await _repository.GetByIdAndUserAsync(
            request.Id,
            request.UserId,
            cancellationToken);

        if (conversation is null)
        {
            return Result.Failure<GetConversationResponse>(ConversationApplicationErrors.ConversationNotFound);
        }

        var response = new GetConversationResponse(
            conversation.Id,
            conversation.CreatedAt,
            conversation.UpdatedAt,
            conversation.Name,
            conversation.ChatbotId,
            conversation.Visual);

        return Result.Success(response);
    }
}