using ChatbotBuilderApi.Domain.Core;
using ChatbotBuilderApi.Domain.Graphs.Nodes;
using ChatbotBuilderApi.Domain.Graphs.Nodes.ApiAction;
using ChatbotBuilderApi.Domain.Graphs.Nodes.Behaviors;
using ChatbotBuilderApi.Domain.Graphs.Nodes.Generation;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Ids;

namespace ChatbotBuilderApi.Domain.Graphs.Traversal;

public sealed class GraphTraversalService : IGraphTraversalService
{
    private readonly NodeExecutionContext _nodeExecutionContext;

    public GraphTraversalService(
        IApiActionService apiActionService,
        IGenerationService generationService)
    {
        _nodeExecutionContext = new NodeExecutionContext(
            apiActionService,
            generationService);
    }

    private Graph? _graph;

    public Graph Graph
    {
        get => _graph ?? throw new DomainException(GraphDomainErrors.GraphTraversal.GraphNotSet);
        set
        {
            _graph = value;
            foreach (var flowLink in _graph.FlowLinks)
            {
                _sourceNodeFlowLinks.TryAdd(flowLink.SourceNodeId, []);
                _sourceNodeFlowLinks[flowLink.SourceNodeId].Add(flowLink.Id);
            }
        }
    }

    /// <remarks>
    /// For O(1) successor lookup
    /// </remarks>
    private readonly Dictionary<NodeId, HashSet<FlowLinkId>> _sourceNodeFlowLinks = [];

    /// <summary>
    /// Runs the lifecycle steps of the node, which includes:
    /// <list type="number">
    /// <item>Running the node's logic </item>
    /// <item>Publishing the node's outputs </item>
    /// </list>
    /// </summary>
    /// <param name="node"></param>
    private async Task ActivateNodeAsync(Node node)
    {
        await node.RunAsync(_nodeExecutionContext);

        if (node is IOutputNode outputNode)
        {
            outputNode.PublishOutputs();
        }
    }

    public async Task InitializeGraphAsync()
    {
        foreach (var setupNode in Graph.Nodes.Where(n => n is ISetupNode))
        {
            await ActivateNodeAsync(setupNode);
        }
    }

    public NodeId GetSuccessor(NodeId nodeId)
    {
        if (!Graph.NodesMap.TryGetValue(nodeId, out var node))
        {
            throw new DomainException(GraphDomainErrors.Graph.NodeDoesNotExist);
        }

        if (node is ISwitchNode switchNode)
        {
            var flowLinkId = switchNode.GetSelectedFlowLinkId();
            return Graph.FlowLinksMap[flowLinkId].TargetNodeId;
        }

        if (!_sourceNodeFlowLinks.TryGetValue(nodeId, out var flowLinkIds))
        {
            throw new DomainException(GraphDomainErrors.Graph.NodeDoesNotExist);
        }

        if (flowLinkIds.Count > 1)
        {
            throw new DomainException(GraphDomainErrors.Graph.NonSwitchNodeHasMultipleOutputFlowLinks);
        }

        return Graph.FlowLinksMap[flowLinkIds.First()].TargetNodeId;
    }

    /// <summary>
    /// Traverses the graph starting from the interaction node until it hits another interaction node.
    /// At each node, it activates the node and then moves to its successor.
    /// </summary>
    /// <returns>The ID of the next interaction node</returns>
    public async Task<NodeId> TraverseAsync(NodeId interactionNodeId)
    {
        if (!Graph.NodesMap.TryGetValue(interactionNodeId, out var interactionNode)
            || interactionNode is not InteractionNode)
        {
            throw new DomainException(GraphDomainErrors.Graph.InteractionNodeNotFound);
        }

        var currentNodeId = interactionNodeId;
        var currentNode = interactionNode;
        do
        {
            await ActivateNodeAsync(currentNode);
            currentNodeId = GetSuccessor(currentNodeId);
            currentNode = Graph.NodesMap[currentNodeId];
        } while (currentNode is not InteractionNode);

        return currentNodeId;
    }
}