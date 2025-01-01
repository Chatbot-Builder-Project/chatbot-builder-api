using ChatbotBuilderApi.Application.Images.GetImage;
using ChatbotBuilderApi.Application.Images.ListImages;
using Riok.Mapperly.Abstractions;

namespace ChatbotBuilderApi.Presentation.Images.ViewModels;

[Mapper]
public static partial class ImageViewModelsMappers
{
    [MapProperty(nameof(GetImageResponse.ImageMeta.IsProfilePicture), nameof(ImageViewModel.IsProfilePicture))]
    public static partial ImageViewModel ToViewModel(this GetImageResponse response);

    [MapProperty(nameof(ListImagesResponseItem.ImageMeta.IsProfilePicture),
        nameof(ImageListViewModelItem.IsProfilePicture))]
    public static partial ImageListViewModelItem ToViewModel(this ListImagesResponseItem response);

    public static partial ImageListViewModel ToViewModel(this ListImagesResponse response);
}