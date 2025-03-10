using ChatbotBuilderApi.Domain.Core.Primitives;

namespace ChatbotBuilderApi.Application.Core.Shared.Responses;

public sealed record CreateResponse<TId>(TId Id)
    where TId : EntityId<TId>;