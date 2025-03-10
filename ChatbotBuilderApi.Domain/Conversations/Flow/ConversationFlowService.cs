﻿using ChatbotBuilderApi.Domain.Conversations.ValueObjects;
using ChatbotBuilderApi.Domain.Core;
using ChatbotBuilderApi.Domain.Graphs;
using ChatbotBuilderApi.Domain.Graphs.Nodes;
using ChatbotBuilderApi.Domain.Graphs.Traversal;

namespace ChatbotBuilderApi.Domain.Conversations.Flow;

public sealed class ConversationFlowService : IConversationFlowService
{
    public IGraphTraversalService GraphTraversalService { get; }

    private Graph Graph => GraphTraversalService.Graph;

    public ConversationFlowService(IGraphTraversalService graphTraversalService)
    {
        GraphTraversalService = graphTraversalService;
    }

    private Conversation? _conversation;

    public Conversation Conversation
    {
        get => _conversation ??
               throw new DomainException(ConversationDomainErrors.ConversationFlow.ConversationNotSet);
        set
        {
            _conversation = value;
            EnsureGraphMatches();
        }
    }

    private void EnsureGraphMatches()
    {
        if (Conversation.GraphId != Graph.Id)
        {
            throw new DomainException(ConversationDomainErrors.ConversationFlow.GraphMismatch);
        }
    }

    /// <summary>
    /// Initializes the graph and generates the first output message.
    /// </summary>
    public async Task InitializeConversationAsync()
    {
        EnsureGraphMatches();

        await GraphTraversalService.InitializeGraphAsync();

        AddOutput();
    }

    /// <summary>
    /// Takes the input message and traverses the graph to generate the next output message.
    /// </summary>
    /// <param name="inputMessage">The user input message</param>
    public async Task ProcessInputMessageAsync(InputMessage inputMessage)
    {
        EnsureGraphMatches();

        AddInput(inputMessage);

        var nextNodeId = await GraphTraversalService.TraverseAsync(Graph.CurrentNodeId);
        Graph.SetCurrentNodeId(nextNodeId);

        AddOutput();
    }

    private InteractionNode GetCurrentInteractionNode()
    {
        if (Graph.GetCurrentNode() is not InteractionNode interactionNode)
        {
            throw new DomainException(ConversationDomainErrors.ConversationFlow.NodeIsNotAnInteractionNode);
        }

        return interactionNode;
    }

    private void AddInput(InputMessage inputMessage)
    {
        GetCurrentInteractionNode().SetInteractionInput(inputMessage.Input);

        Conversation.AddInputMessage(inputMessage);
    }

    private void AddOutput()
    {
        var interactionOutput = GetCurrentInteractionNode().GetInteractionOutput();

        Conversation.AddOutputMessage(OutputMessage.Create(interactionOutput));
    }
}