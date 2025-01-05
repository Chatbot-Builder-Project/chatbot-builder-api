using ChatbotBuilderApi.Application.Core.Shared;

namespace ChatbotBuilderApi.Presentation.Images.QueryParams;

/// <summary>
/// Query parameters for the image list.
/// </summary>
/// <param name="PageParams">Page parameters for the list.</param>
/// <param name="IncludeOnlyProfilePictures">Whether to include only profile pictures.
/// Note that users can only have a single profile picture. So, if this is set to true,
/// only one image at most will be returned.</param>
/// <param name="Search">Only images with names containing this search string will be returned.</param>
public sealed record ImageListQueryParams(
    PageParams PageParams,
    bool? IncludeOnlyProfilePictures,
    string? Search);