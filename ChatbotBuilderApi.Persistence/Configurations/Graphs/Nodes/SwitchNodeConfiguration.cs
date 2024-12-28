using ChatbotBuilderApi.Domain.Graphs.Entities.Nodes;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Data;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Ids;
using ChatbotBuilderApi.Persistence.Configurations.Converters;
using ChatbotBuilderApi.Persistence.Configurations.Graphs.Extensions;
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

        builder.Property(n => n.Bindings)
            .HasConversion(new DictionaryJsonConverter<OptionData, FlowLinkId>())
            .HasColumnType("NVARCHAR(MAX)");

        builder.OwnsOne(n => n.SelectedOption, n => n.ConfigureOptionData());
    }
}