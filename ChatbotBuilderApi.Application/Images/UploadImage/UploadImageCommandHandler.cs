using ChatbotBuilderApi.Application.Core.Abstract;
using ChatbotBuilderApi.Application.Core.Abstract.Messaging;
using ChatbotBuilderApi.Application.Core.Shared;
using ChatbotBuilderApi.Application.Core.Shared.Responses;
using ChatbotBuilderApi.Domain.Images;
using MediatR;

namespace ChatbotBuilderApi.Application.Images.UploadImage;

public sealed class UploadImageCommandHandler : ICommandHandler<UploadImageCommand, CreateResponse<ImageId>>
{
    private readonly IImageRepository _imageRepository;
    private readonly IImageCudRepository _imageCudRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPublisher _publisher;

    public UploadImageCommandHandler(
        IImageRepository imageRepository,
        IImageCudRepository imageCudRepository,
        IUnitOfWork unitOfWork,
        IPublisher publisher)
    {
        _imageRepository = imageRepository;
        _imageCudRepository = imageCudRepository;
        _unitOfWork = unitOfWork;
        _publisher = publisher;
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

        var @event = new ImageUploadedEvent(imageId, request.UserId, request.ImageMeta);
        await _publisher.Publish(@event, CancellationToken.None);

        return Result.Success(new CreateResponse<ImageId>(imageId));
    }
}