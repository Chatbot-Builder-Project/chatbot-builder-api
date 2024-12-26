namespace ChatbotBuilderApi.Application.Graphs.Nodes.Abstract;

public interface IInputNodeDto
{
    IEnumerable<int> GetInputPortIds();
}