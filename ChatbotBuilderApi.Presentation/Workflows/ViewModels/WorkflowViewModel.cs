using ChatbotBuilderApi.Presentation.Graphs;
using ChatbotBuilderApi.Presentation.Graphs.Metas;

namespace ChatbotBuilderApi.Presentation.Workflows.ViewModels;

/// <summary>
/// A workflow view model.
/// </summary>
/// <param name="Id">ID of the workflow.</param>
/// <param name="OwnerId">ID of the owner of the workflow.</param>
/// <param name="CreatedAt">Date and time the workflow was created.</param>
/// <param name="UpdatedAt">Date and time the workflow was last updated.</param>
/// <param name="Name">Name of the workflow.</param>
/// <param name="Description">Description of the workflow.</param>
/// <param name="Graph">Graph of the workflow.</param>
/// <param name="Visual">Generic visual metadata of the workflow.</param>
/// <param name="Stats">(Optional) Statistics of the workflow.</param>
public sealed record WorkflowViewModel(
    Guid Id,
    Guid OwnerId,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    string Name,
    string Description,
    GraphModel Graph,
    VisualMetaModel Visual,
    WorkflowViewModelStats? Stats);

/// <summary>
/// Statistics of the workflow.
/// </summary>
/// <param name="NumberOfChatbots">Number of chatbots that have been published from the workflow.</param>
/// <param name="NumberOfUsers">Number of users that have interacted with any chatbot published from the workflow.</param>
/// <param name="NumberOfConversations">Number of conversations that have taken place with any chatbot published from the workflow.</param>
/// <param name="NumberOfMessages">Number of messages that have been exchanged in all conversations of any chatbot published from the workflow.</param>
public sealed record WorkflowViewModelStats(
    int NumberOfChatbots,
    int NumberOfUsers,
    int NumberOfConversations,
    int NumberOfMessages);