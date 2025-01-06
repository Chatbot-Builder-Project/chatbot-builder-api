using ChatbotBuilderApi.Domain.Graphs.Nodes.Prompt;
using Riok.Mapperly.Abstractions;

namespace ChatbotBuilderApi.Application.Graphs.Nodes.Prompt;

[Mapper]
public static partial class PromptTemplateMapper
{
    public static PromptTemplate ToDomain(this PromptTemplateDto dto) => PromptTemplate.Create(dto.Text);

    public static partial PromptTemplateDto ToDto(this PromptTemplate domain);
}