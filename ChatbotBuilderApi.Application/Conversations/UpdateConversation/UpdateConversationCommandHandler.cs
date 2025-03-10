using ChatbotBuilderApi.Application.Core.Abstract;
using ChatbotBuilderApi.Application.Core.Abstract.Messaging;
using ChatbotBuilderApi.Application.Core.Shared;

namespace ChatbotBuilderApi.Application.Conversations.UpdateConversation;

public sealed class UpdateConversationCommandHandler : ICommandHandler<UpdateConversationCommand>
{
    private readonly IConversationRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateConversationCommandHandler(
        IConversationRepository repository,
        IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateConversationCommand request, CancellationToken cancellationToken)
    {
        var conversation = await _repository.GetByIdAndUserAsync(
            request.Id,
            request.UserId,
            cancellationToken);

        if (conversation is null)
        {
            return Result.Failure(ConversationApplicationErrors.ConversationNotFound);
        }

        conversation.Update(request.Name, request.Visual);
        _repository.Update(conversation);

        await _unitOfWork.CommitAsync(cancellationToken);

        return Result.Success();
    }
}