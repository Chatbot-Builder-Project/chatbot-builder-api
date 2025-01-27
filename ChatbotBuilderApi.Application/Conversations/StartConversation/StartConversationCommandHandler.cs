using ChatbotBuilderApi.Application.Core.Abstract;
using ChatbotBuilderApi.Application.Core.Abstract.Messaging;
using ChatbotBuilderApi.Application.Core.Shared;
using ChatbotBuilderApi.Application.Graphs;
using ChatbotBuilderApi.Domain.Conversations;
using ChatbotBuilderApi.Domain.Conversations.Flow;
using ChatbotBuilderApi.Domain.Conversations.ValueObjects;

namespace ChatbotBuilderApi.Application.Conversations.StartConversation;

public sealed class StartConversationCommandHandler
    : ICommandHandler<StartConversationCommand, StartConversationResponse>
{
    private readonly IConversationRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IConversationFlowService _conversationFlowService;

    public StartConversationCommandHandler(
        IConversationRepository repository,
        IUnitOfWork unitOfWork,
        IConversationFlowService conversationFlowService)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _conversationFlowService = conversationFlowService;
    }

    public async Task<Result<StartConversationResponse>> Handle(StartConversationCommand request,
        CancellationToken cancellationToken)
    {
        var chatbot = await _repository.GetChatbotByIdIfAuthorizedAsync(
            request.ChatbotId,
            request.UserId,
            cancellationToken);

        if (chatbot is null)
        {
            return Result.Failure<StartConversationResponse>(ConversationApplicationErrors.ChatbotNotFound);
        }

        var graph = chatbot.Graph.ToDto().ToDomain();

        var conversation = Conversation.Create(
            new ConversationId(Guid.NewGuid()),
            chatbot.Id,
            graph.Id,
            request.UserId,
            request.Name,
            chatbot.Visual); // Same visual as the chatbot

        _conversationFlowService.GraphTraversalService.Graph = graph;
        _conversationFlowService.Conversation = conversation;
        await _conversationFlowService.InitializeConversationAsync();

        _repository.Add(conversation, graph);
        await _unitOfWork.CommitAsync(cancellationToken);

        var response = new StartConversationResponse(conversation.Id, conversation.OutputMessages[^1]);
        return Result.Success(response);
    }
}