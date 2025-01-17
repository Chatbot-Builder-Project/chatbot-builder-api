using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Data;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Interactions;
using ChatbotBuilderApi.Persistence.Configurations.Converters;
using ChatbotBuilderApi.Persistence.Configurations.Converters.Json;
using ChatbotBuilderApi.Persistence.Configurations.Graphs.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatbotBuilderApi.Persistence.Configurations.Graphs;

internal sealed class InteractionInputConfiguration : IEntityTypeConfiguration<InteractionInput>
{
    public void Configure(EntityTypeBuilder<InteractionInput> builder)
    {
        builder.Property<Guid>("Id").ValueGeneratedOnAdd();
        builder.HasKey("Id");

        builder.OwnsOne(i => i.Text, t => t.ConfigureTextData());
        builder.OwnsOne(i => i.Option, o => o.ConfigureOptionData());
    }
}

internal sealed class InteractionOutputConfiguration : IEntityTypeConfiguration<InteractionOutput>
{
    public void Configure(EntityTypeBuilder<InteractionOutput> builder)
    {
        builder.Property<Guid>("Id").ValueGeneratedOnAdd();
        builder.HasKey("Id");

        builder.OwnsOne(o => o.TextOutput, t => t.ConfigureTextData());

        builder.OwnsMany(o => o.ImageOutputs, i => i.ConfigureImageData());
        builder.Navigation(o => o.ImageOutputs).AutoInclude();

        builder.Property(o => o.TextExpected);
        builder.Property(o => o.OptionExpected);

        builder.Property(o => o.ExpectedOptionMetas)
            .HasConversion(new NullableDictionaryValueConverter<OptionData, InteractionOptionMeta>(
                new OptionDataJsonConverter(),
                new InteractionOptionMetaJsonConverter(
                    new ImageDataJsonConverter()
                )))
            .HasColumnType("NVARCHAR(MAX)")
            .IsRequired(false);
    }
}