using ChatbotBuilderApi.Domain.Graphs.Entities.Links;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Ids;
using ChatbotBuilderApi.Persistence.Configurations.Extensions;
using ChatbotBuilderApi.Persistence.Configurations.Graphs.Links.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatbotBuilderApi.Persistence.Configurations.Graphs.Links;

internal sealed class DataLinkConfiguration : IEntityTypeConfiguration<DataLink>
{
    public void Configure(EntityTypeBuilder<DataLink> builder)
    {
        builder.ConfigureLinkBase<DataLink, DataLinkId>();

        builder.HasKey(l => l.Id);
        builder.Property(l => l.Id).ApplyEntityIdConversion();

        builder.Property(l => l.InputPortId).ApplyEntityIdConversion();
        builder.Property(l => l.OutputPortId).ApplyEntityIdConversion();
    }
}