using ChatbotBuilderApi.Application.Core.Abstract;
using ChatbotBuilderApi.Application.Core.Abstract.Messaging;
using ChatbotBuilderApi.Application.Core.Shared;
using MediatR;

namespace ChatbotBuilderApi.Application.Images.UpdateImage;

public sealed class UpdateImageCommandHandler : ICommandHandler<UpdateImageCommand>
{
    private readonly IImageRepository _imageRepository;
    private readonly IImageCudRepository _imageCudRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPublisher _publisher;

    public UpdateImageCommandHandler(
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

    public async Task<Result> Handle(UpdateImageCommand request, CancellationToken cancellationToken)
    {
        var image = await _imageRepository.GetByIdAndOwnerAsync(request.ImageId, request.OwnerId, cancellationToken);
        if (image is null)
        {
            return Result.Failure(ImageApplicationErrors.ImageNotFound);
        }

        image.Update(request.ImageMeta);
        _imageCudRepository.Update(image);

        await _unitOfWork.CommitAsync(cancellationToken);

        var @event = new ImageUpdatedEvent(image.Id, request.OwnerId, image.Meta);
        await _publisher.Publish(@event, CancellationToken.None);

        return Result.Success();
    }
}