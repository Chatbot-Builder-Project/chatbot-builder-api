using ChatbotBuilderApi.Application.Core.Abstract.Messaging;
using ChatbotBuilderApi.Application.Core.Shared;

namespace ChatbotBuilderApi.Application.Workflows.GetWorkflowStats;

public sealed class GetWorkflowStatsQueryHandler : IQueryHandler<GetWorkflowStatsQuery, GetWorkflowStatsResponse>
{
    private readonly IWorkflowRepository _repository;

    public GetWorkflowStatsQueryHandler(IWorkflowRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<GetWorkflowStatsResponse>> Handle(
        GetWorkflowStatsQuery request,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}