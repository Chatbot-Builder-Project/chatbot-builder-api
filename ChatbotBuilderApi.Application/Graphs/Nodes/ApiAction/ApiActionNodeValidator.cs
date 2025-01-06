using ChatbotBuilderApi.Application.Core;
using ChatbotBuilderApi.Application.Graphs.Ports.InputPorts;
using ChatbotBuilderApi.Application.Graphs.Ports.OutputPorts;
using ChatbotBuilderApi.Application.Graphs.Shared.Data;
using FluentValidation;

namespace ChatbotBuilderApi.Application.Graphs.Nodes.ApiAction;

public sealed class ApiActionNodeValidator : AbstractValidator<ApiActionNodeDto>
{
    public ApiActionNodeValidator()
    {
        RuleFor(x => x.UrlInputPort)
            .SetValidator(new InputPortValidator(DataType.Text));

        RuleFor(x => x.HttpMethod)
            .IsInEnum()
            .WithMessage("HttpMethod must be a valid enum value.");

        When(x => x.Headers is not null, () =>
        {
            RuleForEach(x => x.Headers)
                .Must(kvp => kvp.Key.Length <= ApplicationRules.Strings.MaxMediumStringLength)
                .WithMessage("Header key must be less than or equal to " +
                             ApplicationRules.Strings.MaxMediumStringLength + " characters.")
                .Must(kvp => kvp.Value.Length <= ApplicationRules.Strings.MaxExtraLargeStringLength)
                .WithMessage("Header value must be less than or equal to " +
                             ApplicationRules.Strings.MaxExtraLargeStringLength + " characters.");

            RuleFor(x => x.Headers)
                .Must(x => x!.Count <= 25)
                .WithMessage("Headers must have less than or equal to 25 key-value pairs.");
        });

        RuleFor(x => x.BodyInputPort)
            .SetValidator(new InputPortValidator(DataType.Text)!)
            .When(x => x.BodyInputPort is not null);

        RuleFor(x => x.ResponseOutputPort)
            .SetValidator(new OutputPortValidator(DataType.Text));
    }
}