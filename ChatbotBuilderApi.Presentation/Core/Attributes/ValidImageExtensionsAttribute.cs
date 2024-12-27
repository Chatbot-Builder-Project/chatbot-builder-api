using ChatbotBuilderApi.Application.Core.Constants;

namespace ChatbotBuilderApi.Presentation.Core.Attributes;

public class ValidImageExtensionsAttribute : ValidFileExtensionsAttribute
{
    public ValidImageExtensionsAttribute() : base(GetAllowedExtensions())
    {
    }

    private static string[] GetAllowedExtensions()
    {
        return Enum.GetNames(typeof(ApplicationRules.File.ImageExtensions))
            .Select(x => x.ToLower())
            .ToArray();
    }
}