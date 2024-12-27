using ChatbotBuilderApi.Application.Core.Shared;
using ChatbotBuilderApi.Domain.Core;
using ChatbotBuilderApi.Presentation.Core.Extensions;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ChatbotBuilderApi.Presentation.Core.Filters;

public class DomainExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is not DomainException domainException)
        {
            return;
        }

        context.Result = Result
            .Failure(domainException.Error)
            .ToProblemDetails();

        context.ExceptionHandled = true;
    }
}