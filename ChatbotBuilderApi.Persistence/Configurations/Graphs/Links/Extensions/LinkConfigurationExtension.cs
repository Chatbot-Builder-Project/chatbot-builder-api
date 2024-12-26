using ChatbotBuilderApi.Domain.Core.Primitives;
using ChatbotBuilderApi.Domain.Graphs.Abstract;
using ChatbotBuilderApi.Persistence.Configurations.Graphs.Extensions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatbotBuilderApi.Persistence.Configurations.Graphs.Links.Extensions;

internal static class LinkConfigurationExtension
{
    public static void ConfigureLinkBase<TLink, TId>(this EntityTypeBuilder<TLink> builder)
        where TLink : Link<TId>
        where TId : EntityId<TId>
    {
        builder.OwnsOne(p => p.Info, i => i.ConfigureInfoMeta());
        builder.OwnsOne(p => p.Visual, v => v.ConfigureVisualMeta());
    }
}