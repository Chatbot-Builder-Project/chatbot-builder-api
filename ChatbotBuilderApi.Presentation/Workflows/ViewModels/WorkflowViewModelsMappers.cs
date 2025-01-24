using ChatbotBuilderApi.Application.Workflows.GetWorkflow;
using ChatbotBuilderApi.Application.Workflows.ListWorkflows;
using ChatbotBuilderApi.Presentation.Graphs;
using ChatbotBuilderApi.Presentation.Graphs.Metas;
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
        workflow.Graph.ToModel(),
        workflow.Visual.ToModel());

    public static partial WorkflowListViewModel ToViewModel(this ListWorkflowsResponse workflows);
}