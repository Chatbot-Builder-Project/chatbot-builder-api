using ChatbotBuilderApi.Application.Graphs.Shared.Data;

namespace ChatbotBuilderApi.Presentation.Graphs.Data;

/// <summary>
/// Image data model.
/// </summary>
/// <param name="Url">URL of the image. Typically, brought from the Images endpoints.</param>
public sealed record ImageDataModel(string Url)
    : DataModel(DataType.Image);