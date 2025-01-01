using ChatbotBuilderApi.Application.Core.Shared;

namespace ChatbotBuilderApi.Presentation.Images.QueryParams;

public sealed record ImageListQueryParams(
    PageParams PageParams,
    bool? IncludeOnlyProfilePictures,
    string? Search);