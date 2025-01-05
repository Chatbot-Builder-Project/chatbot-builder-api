namespace ChatbotBuilderApi.Application.Core;

public static class ApplicationRules
{
    public static class Strings
    {
        public const int MaxLargeStringLength = 1000;
        public const int MaxMediumStringLength = 255;
        public const int MaxSmallStringLength = 100;
    }

    public static class Files
    {
        public const int MaxFileSizeInBytes = 10 * 1024 * 1024; // 10 MB
    }
}