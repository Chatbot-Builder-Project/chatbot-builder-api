using ChatbotBuilderApi.Application.Workflows.GetWorkflow;
using ChatbotBuilderApi.Application.Workflows.ListWorkflows;
using ChatbotBuilderApi.Presentation.Graphs;
using Riok.Mapperly.Abstractions;

namespace ChatbotBuilderApi.Presentation.Workflows.ViewModels;

[Mapper]
public static partial class WorkflowViewModelsMappers
{
    public static WorkflowViewModel ToViewModel(this GetWorkflowResponse workflow) => new(
        workflow.Id,
        workflow.OwnerId,
        workflow.CreatedAt,
        workflow.UpdatedAt,
        workflow.Name,
        workflow.Description,
        workflow.Graph.ToModel());

    public static partial WorkflowListViewModelItem ToViewModel(this ListWorkflowsResponseItem workflow);

    public static partial WorkflowListViewModel ToViewModel(this ListWorkflowsResponse workflows);
}