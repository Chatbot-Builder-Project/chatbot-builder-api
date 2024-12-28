using ChatbotBuilderApi.Application.Core.Abstract;
using ChatbotBuilderApi.Application.Core.Shared.Notifications;
using ChatbotBuilderApi.Domain.Core.Abstract;
using MediatR;

namespace ChatbotBuilderApi.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    private readonly IPublisher _publisher;

    public UnitOfWork(AppDbContext context, IMediator publisher)
    {
        _context = context;
        _publisher = publisher;
    }

    public async Task CommitAsync(CancellationToken cancellationToken)
    {
        await using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
        try
        {
            await _publisher.Publish(new TransactionStartNotification(), cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);
            await transaction.CommitAsync(cancellationToken);

            await _publisher.Publish(new TransactionSuccessNotification(), cancellationToken);
            await PublishDomainEventsAsync(cancellationToken);
        }
        catch (Exception)
        {
            await transaction.RollbackAsync(cancellationToken);
            await _publisher.Publish(new TransactionFailureNotification(), cancellationToken);

            throw;
        }
        finally
        {
            await _publisher.Publish(new TransactionCleanupNotification(), cancellationToken);
        }
    }

    /// <summary>
    /// Publishes and then clears all domain events that exist within the current transaction.
    /// </summary>
    private async Task PublishDomainEventsAsync(CancellationToken cancellationToken)
    {
        var aggregateRoots = _context.ChangeTracker
            .Entries<IAggregateRoot>()
            .Where(ee => ee.Entity.DomainEvents.Count != 0)
            .ToList();

        var domainEvents = aggregateRoots
            .SelectMany(ee => ee.Entity.DomainEvents)
            .ToList();

        aggregateRoots.ForEach(ee => ee.Entity.ClearDomainEvents());

        var tasks = domainEvents
            .Select(domainEvent => _publisher.Publish(domainEvent, cancellationToken));

        await Task.WhenAll(tasks);
    }
}