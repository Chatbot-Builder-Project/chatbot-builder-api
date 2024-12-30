using ChatbotBuilderApi.Application.Core.Abstract;
using ChatbotBuilderApi.Application.Core.Abstract.Messaging;
using ChatbotBuilderApi.Application.Core.Shared;
using ChatbotBuilderApi.Domain.Conversations.Abstract;

namespace ChatbotBuilderApi.Application.Conversations.SendMessage;

public sealed class SendMessageCommandHandler : ICommandHandler<SendMessageCommand, SendMessageResponse>
{
    private readonly IConversationRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IConversationFlowService _conversationFlowService;

    public SendMessageCommandHandler(
        IConversationRepository repository,
        IUnitOfWork unitOfWork,
        IConversationFlowService conversationFlowService)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _conversationFlowService = conversationFlowService;
    }

    public async Task<Result<SendMessageResponse>> Handle(
        SendMessageCommand request,
        CancellationToken cancellationToken)
    {
        var conversation = await _repository.LoadByIdAndUserAsync(
            request.ConversationId,
            request.UserId,
            cancellationToken);

        if (conversation is null)
        {
            return Result.Failure<SendMessageResponse>(ConversationsApplicationErrors.ConversationNotFound);
        }

        var graph = (await _repository.LoadGraphAsync(conversation.Id, cancellationToken))!;

        _conversationFlowService.GraphTraversalService.Graph = graph;
        _conversationFlowService.Conversation = conversation;
        await _conversationFlowService.ProcessInputMessageAsync(request.InputMessage);

        _repository.Update(conversation);
        await _unitOfWork.CommitAsync(cancellationToken);

        var response = new SendMessageResponse(conversation.OutputMessages[^1]);
        return Result.Success(response);
    }
}