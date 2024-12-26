using ChatbotBuilderApi.Domain.Graphs.Entities.Nodes;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Data;
using ChatbotBuilderApi.Persistence.Configurations.Graphs.Extensions;
using ChatbotBuilderApi.Persistence.Configurations.Graphs.Nodes.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatbotBuilderApi.Persistence.Configurations.Graphs.Nodes;

internal sealed class TextStaticNodeConfiguration : IEntityTypeConfiguration<StaticNode<TextData>>
{
    public void Configure(EntityTypeBuilder<StaticNode<TextData>> builder)
    {
        builder.ConfigureStaticNode(d => DataConfigurationExtensions.ConfigureTextData<StaticNode<TextData>>(d));
    }
}

internal sealed class OptionStaticNodeConfiguration : IEntityTypeConfiguration<StaticNode<OptionData>>
{
    public void Configure(EntityTypeBuilder<StaticNode<OptionData>> builder)
    {
        builder.ConfigureStaticNode(d => d.ConfigureOptionData());
    }
}

internal sealed class ImageStaticNodeConfiguration : IEntityTypeConfiguration<StaticNode<ImageData>>
{
    public void Configure(EntityTypeBuilder<StaticNode<ImageData>> builder)
    {
        builder.ConfigureStaticNode(d => d.ConfigureImageData());
    }
}