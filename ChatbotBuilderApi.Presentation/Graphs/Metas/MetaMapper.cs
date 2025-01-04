using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Meta;
using Riok.Mapperly.Abstractions;

namespace ChatbotBuilderApi.Presentation.Graphs.Metas;

[Mapper]
public static partial class MetaMapper
{
    public static InfoMetaModel ToModel(this InfoMeta domain) => new(domain.Identifier, domain.Name);

    public static InfoMeta ToDomain(this InfoMetaModel model) => InfoMeta.Create(model.Id, model.Name);

    public static VisualMetaModel ToModel(this VisualMeta domain) => new(domain.X, domain.Y);

    public static VisualMeta ToDomain(this VisualMetaModel model) => VisualMeta.Create(model.X, model.Y);
}