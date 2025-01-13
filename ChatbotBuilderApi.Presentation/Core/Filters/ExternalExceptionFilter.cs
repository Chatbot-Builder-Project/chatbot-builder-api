using ChatbotBuilderApi.Application.Core.Exceptions;
using ChatbotBuilderApi.Application.Core.Shared;
using ChatbotBuilderApi.Presentation.Core.Extensions;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ChatbotBuilderApi.Presentation.Core.Filters;

public class ExternalExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is not ExternalException externalException)
        {
            return;
        }

        context.Result = Result
            .Failure(externalException.Error)
            .ToProblemDetails();

        context.ExceptionHandled = true;
    }
}