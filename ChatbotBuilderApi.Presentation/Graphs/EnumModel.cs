using ChatbotBuilderApi.Presentation.Graphs.Data;
using ChatbotBuilderApi.Presentation.Graphs.Metas;

namespace ChatbotBuilderApi.Presentation.Graphs;

public sealed record EnumModel(
    InfoMetaModel Info,
    IReadOnlyList<OptionDataModel> Options);