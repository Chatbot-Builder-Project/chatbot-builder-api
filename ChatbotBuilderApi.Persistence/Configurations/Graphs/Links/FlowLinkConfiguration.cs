using ChatbotBuilderApi.Domain.Graphs.Entities.Links;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Ids;
using ChatbotBuilderApi.Persistence.Configurations.Extensions;
using ChatbotBuilderApi.Persistence.Configurations.Graphs.Links.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatbotBuilderApi.Persistence.Configurations.Graphs.Links;

internal sealed class FlowLinkConfiguration : IEntityTypeConfiguration<FlowLink>
{
    public void Configure(EntityTypeBuilder<FlowLink> builder)
    {
        builder.ConfigureLinkBase<FlowLink, FlowLinkId>();

        builder.HasKey(l => l.Id);
        builder.Property(l => l.Id).ApplyEntityIdConversion();

        builder.Property(l => l.InputNodeId).ApplyEntityIdConversion();
        builder.Property(l => l.OutputNodeId).ApplyEntityIdConversion();
    }
}