namespace ChatbotBuilderApi.Application.Graphs.Nodes.Abstract;

public interface IOutputNodeDto
{
    IEnumerable<int> GetOutputPortIds();
}