using ChatbotBuilderApi.Domain.Core.Primitives;

namespace ChatbotBuilderApi.Application.Images;

public static class ImageApplicationErrors
{
    public static readonly Error ImageLimitExceeded = Error.ApplicationValidation(
        "ImageLimitExceeded",
        $"The maximum number of images of {ImageApplicationRules.MaxImagesPerUser} has been reached.");

    public static readonly Error ImageNotFound = Error.NotFound(
        "ImageNotFound",
        "The image was not found.");
}