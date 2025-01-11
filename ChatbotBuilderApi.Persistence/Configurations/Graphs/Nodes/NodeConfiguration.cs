using ChatbotBuilderApi.Domain.Graphs.Nodes;
using ChatbotBuilderApi.Domain.Graphs.Nodes.ApiAction;
using ChatbotBuilderApi.Domain.Graphs.Nodes.Generation;
using ChatbotBuilderApi.Domain.Graphs.Nodes.Prompt;
using ChatbotBuilderApi.Domain.Graphs.Nodes.Switch;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Data;
using ChatbotBuilderApi.Persistence.Configurations.Extensions;
using ChatbotBuilderApi.Persistence.Configurations.Graphs.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatbotBuilderApi.Persistence.Configurations.Graphs.Nodes;

internal sealed class NodeConfiguration : IEntityTypeConfiguration<Node>
{
    public void Configure(EntityTypeBuilder<Node> builder)
    {
        builder.HasDiscriminator<string>("NodeType")
            .HasValue<InteractionNode>(nameof(InteractionNode))
            .HasValue<StaticNode<TextData>>(nameof(StaticNode<TextData>) + nameof(TextData))
            .HasValue<StaticNode<ImageData>>(nameof(StaticNode<ImageData>) + nameof(ImageData))
            .HasValue<StaticNode<OptionData>>(nameof(StaticNode<OptionData>) + nameof(OptionData))
            .HasValue<SwitchNode>(nameof(SwitchNode))
            .HasValue<PromptNode>(nameof(PromptNode))
            .HasValue<ApiActionNode>(nameof(ApiActionNode))
            .HasValue<SmartSwitchNode>(nameof(SmartSwitchNode))
            .HasValue<GenerationNode>(nameof(GenerationNode));

        builder.HasKey(n => n.Id);
        builder.Property(n => n.Id).ApplyEntityIdConversion();

        builder.OwnsOne(n => n.Info, i => i.ConfigureInfoMeta());
        builder.OwnsOne(n => n.Visual, v => v.ConfigureVisualMeta());
    }
}