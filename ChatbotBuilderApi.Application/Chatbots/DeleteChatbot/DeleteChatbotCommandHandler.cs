using ChatbotBuilderApi.Application.Core.Abstract;
using ChatbotBuilderApi.Application.Core.Abstract.Messaging;
using ChatbotBuilderApi.Application.Core.Shared;
using MediatR;

namespace ChatbotBuilderApi.Application.Chatbots.DeleteChatbot;

public sealed class DeleteChatbotCommandHandler : ICommandHandler<DeleteChatbotCommand>
{
    private readonly IChatbotRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPublisher _publisher;

    public DeleteChatbotCommandHandler(
        IChatbotRepository repository,
        IUnitOfWork unitOfWork,
        IPublisher publisher)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _publisher = publisher;
    }

    public async Task<Result> Handle(DeleteChatbotCommand request, CancellationToken cancellationToken)
    {
        var chatbot = await _repository.GetByIdAndOwnerAsync(request.Id, request.OwnerId, cancellationToken);
        if (chatbot is null)
        {
            return Result.Failure(ChatbotApplicationErrors.ChatbotNotFound);
        }

        _repository.Delete(chatbot);
        await _unitOfWork.CommitAsync(cancellationToken);

        var @event = new ChatbotDeletedEvent(request.Id, request.OwnerId);
        await _publisher.Publish(@event, CancellationToken.None);

        return Result.Success();
    }
}