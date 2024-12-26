using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Data;
using FluentValidation;

namespace ChatbotBuilderApi.Application.Graphs.Shared.Data;

public sealed class OptionDataValidator : AbstractValidator<OptionData>
{
    public OptionDataValidator()
    {
    }
}