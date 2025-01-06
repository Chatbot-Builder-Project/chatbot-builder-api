using ChatbotBuilderApi.Domain.Graphs.Ports;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Data;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Ids;
using ChatbotBuilderApi.Persistence.Configurations.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatbotBuilderApi.Persistence.Configurations.Graphs.Ports.Extensions;

internal static class OutputPortConfigurationExtension
{
    public static void ConfigureOutputPort<TData>(
        this EntityTypeBuilder<OutputPort<TData>> builder,
        string joinTableName)
        where TData : Data
    {
        builder.HasMany(o => o.InputPorts)
            .WithMany()
            .UsingEntity<OutputInputPortJoin>(
                joinTableName,
                j => j.HasOne<InputPort<TData>>()
                    .WithMany()
                    .HasForeignKey("InputPortId")
                    .OnDelete(DeleteBehavior.NoAction),
                j => j.HasOne<OutputPort<TData>>()
                    .WithMany()
                    .HasForeignKey("OutputPortId")
                    .OnDelete(DeleteBehavior.Cascade), // one cascade is enough
                j =>
                {
                    j.HasKey("OutputPortId", "InputPortId");
                    j.Property(jj => jj.InputPortId).ApplyEntityIdConversion();
                    j.Property(jj => jj.OutputPortId).ApplyEntityIdConversion();
                });

        builder.Navigation(o => o.InputPorts).AutoInclude();
    }
}

internal class OutputInputPortJoin
{
    public required OutputPortId OutputPortId { get; set; }
    public required InputPortId InputPortId { get; set; }
}