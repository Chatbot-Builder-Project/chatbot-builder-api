namespace ChatbotBuilderApi.Application.Graphs.Nodes.Abstract;

public interface ISwitchNodeDto
{
    IEnumerable<int> GetFlowLinkIds();
}