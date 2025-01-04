using ChatbotBuilderApi.Application.Graphs.Shared.Data;

namespace ChatbotBuilderApi.Presentation.Graphs.Data;

/// <summary>
/// Text data model.
/// </summary>
/// <param name="Text">String value containing the text.</param>
public sealed record TextDataModel(string Text)
    : DataModel(DataType.Text);