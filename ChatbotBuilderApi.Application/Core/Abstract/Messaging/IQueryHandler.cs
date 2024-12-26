using ChatbotBuilderApi.Application.Core.Shared;
using MediatR;

namespace ChatbotBuilderApi.Application.Core.Abstract.Messaging;

public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>;