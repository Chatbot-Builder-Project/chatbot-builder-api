using ChatbotBuilderApi.Presentation.Graphs.Data;
using ChatbotBuilderApi.Presentation.Graphs.Metas;

namespace ChatbotBuilderApi.Presentation.Graphs.Enums;

/// <summary>
/// Enum model.
/// </summary>
/// <param name="Info">Generic information for the enum.</param>
/// <param name="Options">List of options for the enum.</param>
public sealed record EnumModel(
    InfoMetaModel Info,
    IReadOnlyList<OptionDataModel> Options);