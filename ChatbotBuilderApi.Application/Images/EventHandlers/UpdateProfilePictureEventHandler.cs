using ChatbotBuilderApi.Application.Core.Abstract.Messaging;
using ChatbotBuilderApi.Application.Core.Shared;
using ChatbotBuilderApi.Application.Images.ListImages;
using ChatbotBuilderApi.Application.Images.UpdateImage;
using ChatbotBuilderApi.Application.Images.UploadImage;
using ChatbotBuilderApi.Domain.Images;
using ChatbotBuilderApi.Domain.Users;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ChatbotBuilderApi.Application.Images.EventHandlers;

public sealed class UpdateUserProfilePictureEventHandler :
    IEventHandler<ImageUploadedEvent>,
    IEventHandler<ImageUpdatedEvent>
{
    private readonly ISender _sender;
    private readonly ILogger<UpdateUserProfilePictureEventHandler> _logger;

    public UpdateUserProfilePictureEventHandler(
        ISender sender,
        ILogger<UpdateUserProfilePictureEventHandler> logger)
    {
        _sender = sender;
        _logger = logger;
    }

    private async Task UpdateOldProfilePicture(
        ImageId newProfileImageId,
        UserId ownerId,
        CancellationToken cancellationToken)
    {
        _logger.LogInformation(
            "New profile picture uploaded {@ImageId} for user {@UserId}",
            newProfileImageId,
            ownerId);

        var query = new ListImagesQuery
        {
            PageParams = new PageParams(1, 3),
            OwnerId = ownerId,
            IncludeOnlyProfilePictures = true
        };
        var image = await _sender.Send(query, cancellationToken);

        if (image.IsFailure)
        {
            throw new InvalidOperationException("Failed to get old profile picture!");
        }

        var images = image.Value.Page.Items
            .Where(i => i.Id != newProfileImageId)
            .ToList();

        switch (images.Count)
        {
            case 0:
                return; // No old profile picture found
            case > 1:
                _logger.LogError("Multiple profile pictures found for user {UserId}", ownerId);
                throw new InvalidOperationException("Multiple profile pictures found!");
        }

        var oldProfileImage = images[0];

        var command = new UpdateImageCommand
        {
            ImageId = oldProfileImage.Id,
            ImageMeta = ImageMeta.Create(false),
            OwnerId = ownerId
        };

        _logger.LogInformation(
            "Updating old profile picture {@Image} for user {@UserId}",
            oldProfileImage,
            ownerId);

        await _sender.Send(command, cancellationToken);
    }

    public async Task Handle(ImageUploadedEvent notification, CancellationToken cancellationToken)
    {
        if (notification.ImageMeta.IsProfilePicture)
        {
            await UpdateOldProfilePicture(notification.ImageId, notification.OwnerId, cancellationToken);
        }
    }

    public async Task Handle(ImageUpdatedEvent notification, CancellationToken cancellationToken)
    {
        if (notification.ImageMeta.IsProfilePicture)
        {
            await UpdateOldProfilePicture(notification.ImageId, notification.OwnerId, cancellationToken);
        }
    }
}