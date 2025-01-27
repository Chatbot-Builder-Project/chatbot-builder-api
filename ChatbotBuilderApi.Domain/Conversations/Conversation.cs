using ChatbotBuilderApi.Domain.Chatbots.ValueObjects;
using ChatbotBuilderApi.Domain.Conversations.ValueObjects;
using ChatbotBuilderApi.Domain.Core;
using ChatbotBuilderApi.Domain.Core.Primitives;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Ids;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Meta;

namespace ChatbotBuilderApi.Domain.Conversations;

public sealed class Conversation : AggregateRoot<ConversationId>
{
    private readonly List<InputMessage> _inputMessages = [];
    private readonly List<OutputMessage> _outputMessages = [];

    public string Name { get; private set; } = null!;
    public ChatbotId ChatbotId { get; } = null!;
    public GraphId GraphId { get; } = null!;
    public Guid OwnerId { get; } // UserId is incompatible with IdentityUser<Guid>
    public VisualMeta Visual { get; private set; } = null!;
    public IReadOnlyList<InputMessage> InputMessages => _inputMessages;
    public IReadOnlyList<OutputMessage> OutputMessages => _outputMessages;

    private Conversation(
        ConversationId id,
        ChatbotId chatbotId,
        GraphId graphId,
        Guid ownerId,
        string name,
        VisualMeta visual)
        : base(id)
    {
        ChatbotId = chatbotId;
        Name = name;
        GraphId = graphId;
        OwnerId = ownerId;
        Visual = visual;
    }

    /// <inheritdoc/>
    private Conversation()
    {
    }

    public static Conversation Create(
        ConversationId id,
        ChatbotId chatbotId,
        GraphId graphId,
        Guid ownerId,
        string name,
        VisualMeta visual)
    {
        return new Conversation(id, chatbotId, graphId, ownerId, name, visual);
    }

    public void Update(string name, VisualMeta visual)
    {
        Name = name;
        Visual = visual;
    }

    public void AddInputMessage(InputMessage inputMessage)
    {
        if (inputMessage.CreatedAt < _outputMessages.LastOrDefault()?.CreatedAt)
        {
            throw new DomainException(ConversationDomainErrors.Conversation.InputMessageIsOutOfOrder);
        }

        _inputMessages.Add(inputMessage);
    }

    public void AddOutputMessage(OutputMessage outputMessage)
    {
        if (outputMessage.CreatedAt < _inputMessages.LastOrDefault()?.CreatedAt)
        {
            throw new DomainException(ConversationDomainErrors.Conversation.OutputMessageIsOutOfOrder);
        }

        _outputMessages.Add(outputMessage);
    }
}