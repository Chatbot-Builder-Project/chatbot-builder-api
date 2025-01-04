using ChatbotBuilderApi.Application.Graphs.Shared.Data;

namespace ChatbotBuilderApi.Presentation.Graphs.Data;

/// <summary>
/// Option data model.
/// </summary>
/// <param name="Option">String value representing the option.</param>
public sealed record OptionDataModel(string Option)
    : DataModel(DataType.Option);