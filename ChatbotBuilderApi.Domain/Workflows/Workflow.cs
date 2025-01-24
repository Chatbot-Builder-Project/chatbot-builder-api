using ChatbotBuilderApi.Domain.Core.Primitives;
using ChatbotBuilderApi.Domain.Graphs;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Meta;
using ChatbotBuilderApi.Domain.Users;

namespace ChatbotBuilderApi.Domain.Workflows;

public sealed class Workflow : AggregateRoot<WorkflowId>
{
    public string Name { get; private set; } = null!;
    public string Description { get; private set; } = null!;
    public Guid OwnerId { get; } // UserId is incompatible with IdentityUser<Guid>
    public Graph Graph { get; private set; } = null!;
    public VisualMeta Visual { get; private set; } = null!;

    private Workflow(
        WorkflowId id,
        string name,
        string description,
        UserId ownerId,
        Graph graph,
        VisualMeta visual)
        : base(id)
    {
        Name = name;
        Description = description;
        OwnerId = ownerId;
        Graph = graph;
        Visual = visual;
    }

    /// <inheritdoc/>
    private Workflow()
    {
    }

    public static Workflow Create(
        WorkflowId id,
        string name,
        string description,
        UserId ownerId,
        Graph graph,
        VisualMeta visual)
    {
        return new Workflow(id, name, description, ownerId, graph, visual);
    }

    public void Update(
        string name,
        string description,
        Graph graph,
        VisualMeta visual)
    {
        Name = name;
        Description = description;
        Graph = graph;
        Visual = visual;
    }
}