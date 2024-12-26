using ChatbotBuilderApi.Domain.Graphs.Abstract;
using ChatbotBuilderApi.Persistence.Configurations.Graphs.Extensions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatbotBuilderApi.Persistence.Configurations.Graphs.Nodes.Extensions;

internal static class NodeConfigurationExtension
{
    public static void ConfigureNodeBase<TNode>(
        this EntityTypeBuilder<TNode> builder)
        where TNode : Node
    {
        builder.OwnsOne(n => n.Info, i => i.ConfigureInfoMeta());
        builder.OwnsOne(n => n.Visual, v => v.ConfigureVisualMeta());
    }
}