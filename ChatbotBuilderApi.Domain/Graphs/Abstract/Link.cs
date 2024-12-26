using ChatbotBuilderApi.Domain.Core.Primitives;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Meta;

namespace ChatbotBuilderApi.Domain.Graphs.Abstract;

public abstract class Link<TId> : Entity<TId>
    where TId : EntityId<TId>
{
    public InfoMeta Info { get; } = null!;
    public VisualMeta Visual { get; } = null!;

    protected Link(
        TId id,
        InfoMeta info,
        VisualMeta visual)
        : base(id)
    {
        Info = info;
        Visual = visual;
    }

    /// <inheritdoc/>
    protected Link()
    {
    }
}