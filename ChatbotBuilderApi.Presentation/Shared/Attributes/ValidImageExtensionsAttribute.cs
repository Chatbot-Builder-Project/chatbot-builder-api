using ChatbotBuilderApi.Application.Constants;

namespace ChatbotBuilderApi.Presentation.Shared.Attributes;

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