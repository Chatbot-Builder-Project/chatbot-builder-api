using ChatbotBuilderApi.Application.Core.Shared;
using ChatbotBuilderApi.Domain.Images;
using ChatbotBuilderApi.Domain.Users;

namespace ChatbotBuilderApi.Application.Images;

public interface IImageCudRepository
{
    /// <summary>
    /// On commit, the image will be uploaded to the file storage.
    /// And a new image entity will be created and added to the database.
    /// </summary>
    /// <returns>The ID of the image that will be created on commit.</returns>
    ImageId UploadAndAdd(FileUpload fileUpload, UserId ownerId, ImageMeta imageMeta);

    void Update(Image image);

    /// <remarks>The image from the file storage will also be deleted.</remarks>
    void Delete(Image image);
}