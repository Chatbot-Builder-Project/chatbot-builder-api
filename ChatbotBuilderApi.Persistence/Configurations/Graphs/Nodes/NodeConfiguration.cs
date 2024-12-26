using ChatbotBuilderApi.Domain.Graphs.Abstract;
using ChatbotBuilderApi.Persistence.Configurations.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatbotBuilderApi.Persistence.Configurations.Graphs.Nodes;

internal sealed class NodeConfiguration : IEntityTypeConfiguration<Node>
{
    public void Configure(EntityTypeBuilder<Node> builder)
    {
        builder.UseTpcMappingStrategy();

        builder.HasKey(n => n.Id);
        builder.Property(n => n.Id).ApplyEntityIdConversion();
    }
}