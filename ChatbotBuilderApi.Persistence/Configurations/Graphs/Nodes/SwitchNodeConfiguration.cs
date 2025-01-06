using ChatbotBuilderApi.Domain.Graphs.Nodes;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Data;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Ids;
using ChatbotBuilderApi.Persistence.Configurations.Converters;
using ChatbotBuilderApi.Persistence.Configurations.Converters.Json;
using ChatbotBuilderApi.Persistence.Configurations.Graphs.Extensions;
using ChatbotBuilderApi.Persistence.Configurations.Graphs.Nodes.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatbotBuilderApi.Persistence.Configurations.Graphs.Nodes;

internal sealed class SwitchNodeConfiguration : IEntityTypeConfiguration<SwitchNode>
{
    public void Configure(EntityTypeBuilder<SwitchNode> builder)
    {
        builder.HasOne(n => n.InputPort)
            .WithOne()
            .HasForeignKey<SwitchNode>()
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(n => n.Enum)
            .WithMany()
            .IsRequired(false)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Navigation(n => n.InputPort).AutoInclude();
        builder.Navigation(n => n.Enum).AutoInclude();

        builder.FixNodePort<InputPortId>(nameof(SwitchNode.InputPort));
        builder.FixNodeEnum(nameof(SwitchNode.Enum));

        builder.Property(n => n.Bindings)
            .HasConversion(new DictionaryValueConverter<OptionData, FlowLinkId>(
                new OptionDataJsonConverter(),
                new FlowLinkIdJsonConverter()))
            .HasColumnType("NVARCHAR(MAX)");

        builder.OwnsOne(n => n.SelectedOption, n => n.ConfigureOptionData());
    }
}