using ChatbotBuilderApi.Application.Images;

namespace ChatbotBuilderApi.Presentation.Core.Attributes;

public class ValidImageExtensionsAttribute : ValidFileExtensionsAttribute
{
    public ValidImageExtensionsAttribute() : base(GetAllowedExtensions())
    {
    }

    private static string[] GetAllowedExtensions()
    {
        return Enum.GetNames(typeof(ImageApplicationRules.AllowedExtensions))
            .Select(x => x.ToLower())
            .ToArray();
    }
}