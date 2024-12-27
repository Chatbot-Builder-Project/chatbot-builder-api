using ChatbotBuilderApi.Application.Core.Shared.Responses;
using ChatbotBuilderApi.Domain.Core.Primitives;
using ChatbotBuilderApi.Presentation.Core.Responses;
using Riok.Mapperly.Abstractions;

namespace ChatbotBuilderApi.Presentation.Core.Extensions;

[Mapper]
public static partial class CommonMappers
{
    public static CreateResponse ToResponse<TId>(this CreateResponse<TId> response)
        where TId : EntityId<TId> => new(response.Id);
}