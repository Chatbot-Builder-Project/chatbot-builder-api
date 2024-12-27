using ChatbotBuilderApi.Application.Graphs.Shared.Data;

namespace ChatbotBuilderApi.Presentation.Graphs.Data;

public sealed record OptionDataModel(string Option)
    : DataModel(DataType.Option);