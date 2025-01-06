using ChatbotBuilderApi.Domain.Graphs.Nodes.ApiAction;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Ids;
using ChatbotBuilderApi.Persistence.Configurations.Converters;
using ChatbotBuilderApi.Persistence.Configurations.Graphs.Nodes.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatbotBuilderApi.Persistence.Configurations.Graphs.Nodes;

internal sealed class ApiActionNodeConfiguration : IEntityTypeConfiguration<ApiActionNode>
{
    public void Configure(EntityTypeBuilder<ApiActionNode> builder)
    {
        builder.Property(n => n.HttpMethod)
            .HasConversion<string>()
            .HasMaxLength(10)
            .IsRequired();

        builder.HasOne(n => n.UrlInputPort)
            .WithOne()
            .HasForeignKey<ApiActionNode>()
            .IsRequired(false)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(n => n.BodyInputPort)
            .WithOne()
            .HasForeignKey<ApiActionNode>()
            .IsRequired(false)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(n => n.ResponseOutputPort)
            .WithOne()
            .HasForeignKey<ApiActionNode>()
            .IsRequired(false)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Navigation(n => n.UrlInputPort).AutoInclude();
        builder.Navigation(n => n.BodyInputPort).AutoInclude();
        builder.Navigation(n => n.ResponseOutputPort).AutoInclude();

        builder.FixNodePort<InputPortId>(nameof(ApiActionNode.UrlInputPort));
        builder.FixNodePort<InputPortId>(nameof(ApiActionNode.BodyInputPort));
        builder.FixNodePort<OutputPortId>(nameof(ApiActionNode.ResponseOutputPort));

        builder.Property(n => n.Headers)
            .HasConversion(new NullableDictionaryValueConverter<string, string>())
            .HasColumnType("NVARCHAR(MAX)")
            .IsRequired(false);
    }
}