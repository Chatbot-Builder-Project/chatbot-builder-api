using ChatbotBuilderApi.Application.Core.Shared;
using MediatR;

namespace ChatbotBuilderApi.Application.Core.Abstract.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>;