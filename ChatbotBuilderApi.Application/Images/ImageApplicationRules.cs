namespace ChatbotBuilderApi.Application.Images;

public static class ImageApplicationRules
{
    public static int MaxImagesPerUser { get; } = 100;
    public static int MaxImageSizeInBytes { get; } = 5 * 1024 * 1024; // 5MB

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