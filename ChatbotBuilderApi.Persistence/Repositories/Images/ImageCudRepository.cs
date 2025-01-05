using ChatbotBuilderApi.Application.Core.Abstract;
using ChatbotBuilderApi.Application.Core.Abstract.Messaging;
using ChatbotBuilderApi.Application.Core.Notifications;
using ChatbotBuilderApi.Application.Core.Shared;
using ChatbotBuilderApi.Application.Images;
using ChatbotBuilderApi.Domain.Images;
using ChatbotBuilderApi.Domain.Users;

namespace ChatbotBuilderApi.Persistence.Repositories.Images;

public sealed class ImageCudRepository :
    CudRepository<Image>,
    IImageCudRepository,
    ITransactionHandler
{
    private readonly IFileService _fileService;

    public ImageCudRepository(AppDbContext context, IFileService fileService) : base(context)
    {
        _fileService = fileService;
    }

    private readonly List<Func<Task>> _tasks = [];
    private readonly List<Func<Task>> _fallbacks = [];
    private readonly Dictionary<ImageId, Image> _uploadedImages = [];

    public ImageId UploadAndAdd(FileUpload fileUpload, UserId ownerId, ImageMeta imageMeta)
    {
        var imageId = new ImageId(Guid.NewGuid());

        _tasks.Add(async () =>
        {
            var url = await _fileService.UploadFileAsync(fileUpload);

            var image = Image.Create(
                imageId,
                url,
                fileUpload.FileName,
                fileUpload.ContentType,
                ownerId,
                imageMeta);

            _uploadedImages.Add(imageId, image);

            Add(image);
        });

        _fallbacks.Add(async () =>
        {
            if (_uploadedImages.TryGetValue(imageId, out var image))
            {
                await _fileService.DeleteFileAsync(image.Url);
                _uploadedImages.Remove(imageId);
            }
        });

        return imageId;
    }

    public new void Delete(Image image)
    {
        _tasks.Add(async () =>
        {
            await _fileService.DeleteFileAsync(image.Url);
            base.Delete(image);
        });
    }

    public async Task Handle(TransactionStartNotification notification, CancellationToken cancellationToken)
    {
        foreach (var task in _tasks)
        {
            await task();
        }
    }

    public Task Handle(TransactionSuccessNotification notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    public async Task Handle(TransactionFailureNotification notification, CancellationToken cancellationToken)
    {
        foreach (var fallback in _fallbacks)
        {
            await fallback();
        }
    }

    public Task Handle(TransactionCleanupNotification notification, CancellationToken cancellationToken)
    {
        _tasks.Clear();
        _fallbacks.Clear();
        _uploadedImages.Clear();
        return Task.CompletedTask;
    }
}