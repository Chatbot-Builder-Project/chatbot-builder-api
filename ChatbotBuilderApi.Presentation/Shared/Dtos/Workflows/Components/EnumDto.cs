using ChatbotBuilderApi.Presentation.Shared.Dtos.Workflows.Abstract;

namespace ChatbotBuilderApi.Presentation.Shared.Dtos.Workflows.Components;

public class EnumDto : ComponentDto
{
    public List<string> Options { get; set; } = [];
}