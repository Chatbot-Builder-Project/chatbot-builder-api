using ChatbotBuilderApi.Application.Core.Shared.Notifications;
using MediatR;

namespace ChatbotBuilderApi.Application.Core.Abstract.Messaging;

/// <summary>
/// Implement this when you want to handle some logic within a unit of work transaction.
/// </summary>
public interface ITransactionHandler :
    INotificationHandler<TransactionStartNotification>,
    INotificationHandler<TransactionSuccessNotification>,
    INotificationHandler<TransactionFailureNotification>,
    INotificationHandler<TransactionCleanupNotification>;