using ChatbotBuilderApi.Application.Core.Abstract.Messaging;
using ChatbotBuilderApi.Application.Core.Shared;

namespace ChatbotBuilderApi.Application.Images.GetImage;

public sealed class GetImageQueryHandler : IQueryHandler<GetImageQuery, GetImageResponse>
{
    private readonly IImageRepository _imageRepository;

    public GetImageQueryHandler(IImageRepository imageRepository)
    {
        _imageRepository = imageRepository;
    }

    public async Task<Result<GetImageResponse>> Handle(GetImageQuery request, CancellationToken cancellationToken)
    {
        var image = await _imageRepository.GetByIdAndOwnerAsync(request.ImageId, request.OwnerId, cancellationToken);
        if (image is null)
        {
            return Result.Failure<GetImageResponse>(ImageApplicationErrors.ImageNotFound);
        }

        var response = new GetImageResponse(
            image.Id,
            image.CreatedAt,
            image.UpdatedAt,
            image.Url,
            image.Name,
            image.ContentType,
            image.Meta);

        return Result.Success(response);
    }
}