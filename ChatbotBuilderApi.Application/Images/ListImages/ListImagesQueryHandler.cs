using ChatbotBuilderApi.Application.Core.Abstract.Messaging;
using ChatbotBuilderApi.Application.Core.Shared;

namespace ChatbotBuilderApi.Application.Images.ListImages;

public sealed class ListImagesQueryHandler : IQueryHandler<ListImagesQuery, ListImagesResponse>
{
    private readonly IImageRepository _imageRepository;

    public ListImagesQueryHandler(IImageRepository imageRepository)
    {
        _imageRepository = imageRepository;
    }

    public async Task<Result<ListImagesResponse>> Handle(ListImagesQuery request, CancellationToken cancellationToken)
    {
        var page = await _imageRepository.ListByQueryAsync(request, cancellationToken);
        var response = new ListImagesResponse(page);
        return Result.Success(response);
    }
}