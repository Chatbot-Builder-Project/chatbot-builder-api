using ChatbotBuilderApi.Domain.Chatbots.ValueObjects;
using ChatbotBuilderApi.Domain.Core.Primitives;
using ChatbotBuilderApi.Domain.Graphs;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Data;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Meta;
using ChatbotBuilderApi.Domain.Workflows;
using Version = ChatbotBuilderApi.Domain.Chatbots.ValueObjects.Version;

namespace ChatbotBuilderApi.Domain.Chatbots;

public sealed class Chatbot : AggregateRoot<ChatbotId>
{
    public string Name { get; private set; } = null!;
    public string Description { get; private set; } = null!;
    public WorkflowId WorkflowId { get; } = null!;
    public Version Version { get; } = null!;
    public Graph Graph { get; } = null!;
    public bool IsPublic { get; private set; }
    public ImageData? AvatarImageData { get; private set; }
    public VisualMeta Visual { get; private set; } = null!;

    private Chatbot(
        ChatbotId id,
        string name,
        string description,
        WorkflowId workflowId,
        Version version,
        Graph graph,
        bool isPublic,
        ImageData? avatarImageData,
        VisualMeta visual)
        : base(id)
    {
        Name = name;
        Description = description;
        WorkflowId = workflowId;
        Version = version;
        Graph = graph;
        IsPublic = isPublic;
        AvatarImageData = avatarImageData;
        Visual = visual;
    }

    /// <inheritdoc/>
    private Chatbot()
    {
    }

    public static Chatbot Create(
        ChatbotId id,
        string name,
        string description,
        WorkflowId workflowId,
        Version version,
        Graph graph,
        bool isPublic,
        ImageData? avatarImageData,
        VisualMeta visual)
    {
        return new Chatbot(
            id,
            name,
            description,
            workflowId,
            version,
            graph,
            isPublic,
            avatarImageData,
            visual);
    }

    public void Update(
        string name,
        string description,
        bool isPublic,
        ImageData? avatarImageData,
        VisualMeta visual)
    {
        Name = name;
        Description = description;
        IsPublic = isPublic;
        AvatarImageData = avatarImageData;
        Visual = visual;
    }
}