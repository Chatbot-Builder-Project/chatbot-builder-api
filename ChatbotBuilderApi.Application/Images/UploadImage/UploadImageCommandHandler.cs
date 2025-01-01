using ChatbotBuilderApi.Application.Core.Abstract;
using ChatbotBuilderApi.Application.Core.Abstract.Messaging;
using ChatbotBuilderApi.Application.Core.Shared;
using ChatbotBuilderApi.Application.Core.Shared.Responses;
using ChatbotBuilderApi.Domain.Images;

namespace ChatbotBuilderApi.Application.Images.UploadImage;

public sealed class UploadImageCommandHandler : ICommandHandler<UploadImageCommand, CreateResponse<ImageId>>
{
    private readonly IImageRepository _imageRepository;
    private readonly IImageCudRepository _imageCudRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UploadImageCommandHandler(
        IImageRepository imageRepository,
        IImageCudRepository imageCudRepository,
        IUnitOfWork unitOfWork)
    {
        _imageRepository = imageRepository;
        _imageCudRepository = imageCudRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<CreateResponse<ImageId>>> Handle(
        UploadImageCommand request,
        CancellationToken cancellationToken)
    {
        var imageCount = await _imageRepository.GetCountByOwnerAsync(
            request.UserId,
            cancellationToken);

        if (imageCount >= ImageApplicationRules.MaxImagesPerUser)
        {
            return Result.Failure<CreateResponse<ImageId>>(ImageApplicationErrors.ImageLimitExceeded);
        }

        var imageId = _imageCudRepository.UploadAndAdd(
            request.FileUpload,
            request.UserId,
            request.ImageMeta);

        await _unitOfWork.CommitAsync(cancellationToken);

        return Result.Success(new CreateResponse<ImageId>(imageId));
    }
}