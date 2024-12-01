using ChatbotBuilderApi.Presentation.Features.Shared.Dtos.Workflows.Abstract;

namespace ChatbotBuilderApi.Presentation.Features.Shared.Dtos.Workflows.Components;

public class EnumDto : ComponentDto
{
    public List<string> Options { get; set; } = [];
}