using ChatbotBuilderApi.Application.Core.Abstract;
using ChatbotBuilderApi.Application.Core.Abstract.Messaging;
using ChatbotBuilderApi.Application.Core.Shared;

namespace ChatbotBuilderApi.Application.Images.DeleteImage;

public sealed class DeleteImageCommandHandler : ICommandHandler<DeleteImageCommand>
{
    private readonly IImageRepository _imageRepository;
    private readonly IImageCudRepository _imageCudRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteImageCommandHandler(
        IImageRepository imageRepository,
        IImageCudRepository imageCudRepository,
        IUnitOfWork unitOfWork)
    {
        _imageRepository = imageRepository;
        _imageCudRepository = imageCudRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteImageCommand request, CancellationToken cancellationToken)
    {
        var image = await _imageRepository.GetByIdAndOwnerAsync(request.ImageId, request.OwnerId, cancellationToken);
        if (image is null)
        {
            return Result.Failure(ImageApplicationErrors.ImageNotFound);
        }

        _imageCudRepository.Delete(image);
        await _unitOfWork.CommitAsync(cancellationToken);

        return Result.Success();
    }
}