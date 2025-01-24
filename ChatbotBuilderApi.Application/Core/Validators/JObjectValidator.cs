using FluentValidation;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ChatbotBuilderApi.Application.Core.Validators;

public sealed class JObjectValidator : AbstractValidator<JObject?>
{
    public JObjectValidator()
    {
        RuleFor(x => x)
            .Must(data => IsJsonSizeValid(data, ApplicationRules.Files.MaxJsonSizeInBytes))
            .WithMessage($"The JSON data exceeds the maximum allowed size of " +
                         $"{ApplicationRules.Files.MaxJsonSizeInBytes} bytes.");
    }

    private static bool IsJsonSizeValid(JObject? data, int maxSizeInBytes)
    {
        if (data is null)
        {
            return true;
        }

        var jsonString = JsonConvert.SerializeObject(data);

        var sizeInBytes = System.Text.Encoding.UTF8.GetByteCount(jsonString);

        return sizeInBytes <= maxSizeInBytes;
    }
}