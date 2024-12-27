using ChatbotBuilderApi.Application.Graphs.Shared.Data;

namespace ChatbotBuilderApi.Presentation.Graphs.Data;

public sealed record ImageDataModel(string Url)
    : DataModel(DataType.Image);