namespace ChatbotBuilderApi.Application.Images;

public static class ImageApplicationRules
{
    public static int MaxImagesPerUser { get; } = 100;

    public enum AllowedExtensions
    {
        Jpg,
        Jpeg,
        Png,
        Gif,
        Bmp,
        Tiff,
        Svg,
        Webp,
        Ico
    }
}