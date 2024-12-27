namespace ChatbotBuilderApi.Presentation.Shared.Dtos.Data;

public class OptionDataDto : DataDto
{
    public int EnumId { get; set; }
    public string Option { get; set; } = string.Empty;
}