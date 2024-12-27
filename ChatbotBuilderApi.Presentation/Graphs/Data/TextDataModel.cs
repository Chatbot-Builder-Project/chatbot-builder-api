using ChatbotBuilderApi.Application.Graphs.Shared.Data;

namespace ChatbotBuilderApi.Presentation.Graphs.Data;

public sealed record TextDataModel(string Text)
    : DataModel(DataType.Text);