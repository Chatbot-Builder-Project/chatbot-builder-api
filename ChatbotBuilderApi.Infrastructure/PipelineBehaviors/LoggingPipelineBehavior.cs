﻿using ChatbotBuilderApi.Application.Core.Exceptions;
using ChatbotBuilderApi.Application.Core.Shared;
using ChatbotBuilderApi.Domain.Core;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ChatbotBuilderApi.Infrastructure.PipelineBehaviors;

public class LoggingPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : Result
{
    private readonly ILogger<LoggingPipelineBehavior<TRequest, TResponse>> _logger;

    public LoggingPipelineBehavior(ILogger<LoggingPipelineBehavior<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        _logger.LogInformation(
            "Starting request {@RequestName}, {@DateTimeUtc}",
            typeof(TRequest).Name,
            DateTime.UtcNow);

        try
        {
            var result = await next();

            if (result.IsFailure)
            {
                _logger.LogError(
                    "Request failure {@RequestName}, {@Error}, {@DateTimeUtc}\n" +
                    "Request details: {@Request}",
                    typeof(TRequest).Name,
                    result.Error,
                    DateTime.UtcNow,
                    request);
            }

            return result;
        }
        catch (ValidationException ex)
        {
            _logger.LogError(
                "Request validation failure {@RequestName}, {@ValidationErrors}, {@DateTimeUtc}\n" +
                "Request details: {@Request}",
                typeof(TRequest).Name,
                ex.Errors,
                DateTime.UtcNow,
                request);

            throw;
        }
        catch (DomainException ex)
        {
            _logger.LogError(
                "Request domain failure {@RequestName}, {@Error}, {@DateTimeUtc}\n" +
                "Request details: {@Request}",
                typeof(TRequest).Name,
                ex.Error,
                DateTime.UtcNow,
                request);

            throw;
        }
        catch (ExternalException ex)
        {
            _logger.LogError(
                "Request external failure {@RequestName}, {@Error}, {@DateTimeUtc}\n" +
                "Request details: {@Request}",
                typeof(TRequest).Name,
                ex.Error,
                DateTime.UtcNow,
                request);

            throw;
        }
        catch (Exception ex)
        {
            _logger.LogError(
                ex,
                "Request exception {@RequestName}, {@DateTimeUtc}\n" +
                "Request details: {@Request}",
                typeof(TRequest).Name,
                DateTime.UtcNow,
                request);

            throw;
        }
        finally
        {
            _logger.LogInformation(
                "Completed request {@RequestName}, {@DateTimeUtc}",
                typeof(TRequest).Name,
                DateTime.UtcNow);
        }
    }
}