namespace ChatbotBuilderApi.Application.Core.Abstract;

public interface IUnitOfWork
{
    Task CommitAsync(CancellationToken cancellationToken);
}