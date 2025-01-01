using ChatbotBuilderApi.Application.Core.Shared.Responses;

namespace ChatbotBuilderApi.Presentation.Images.ViewModels;

public sealed record ImageListViewModel(PageResponse<ImageListViewModelItem> Page);

public sealed record ImageListViewModelItem(
    Guid Id,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    string Url,
    string Name,
    string ContentType,
    bool IsProfilePicture);