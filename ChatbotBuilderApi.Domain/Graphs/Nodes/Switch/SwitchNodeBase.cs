using ChatbotBuilderApi.Domain.Core;
using ChatbotBuilderApi.Domain.Graphs.Nodes.Behaviors;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Data;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Ids;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Meta;

namespace ChatbotBuilderApi.Domain.Graphs.Nodes.Switch;

/// <summary>
/// A node that determines the flow link to follow based on its current state.
/// Leaves the implementation of setting the SelectedOption to the derived class.
/// </summary>
public abstract class SwitchNodeBase : Node,
    IEnumNode, ISwitchNode
{
    public Enum Enum { get; } = null!;
    public IReadOnlyDictionary<OptionData, FlowLinkId> Bindings { get; } = null!;
    public OptionData? SelectedOption { get; protected set; }

    protected SwitchNodeBase(
        NodeId id,
        InfoMeta info,
        VisualMeta visual,
        Enum @enum,
        IReadOnlyDictionary<OptionData, FlowLinkId> bindings)
        : base(id, info, visual)
    {
        Enum = @enum;
        Bindings = bindings;
    }

    /// <inheritdoc/>
    protected SwitchNodeBase()
    {
    }

    public IEnumerable<EnumId> GetEnumIds()
    {
        yield return Enum.Id;
    }

    public IEnumerable<FlowLinkId> GetFlowLinkIds()
    {
        return Bindings.Values;
    }

    public FlowLinkId GetSelectedFlowLinkId()
    {
        if (SelectedOption is null)
        {
            throw new DomainException(GraphDomainErrors.SwitchNode.HasNotBeenActivated);
        }

        if (!Bindings.TryGetValue(SelectedOption, out var flowLinkId))
        {
            throw new DomainException(GraphDomainErrors.SwitchNode.OptionNotBound);
        }

        return flowLinkId;
    }
}