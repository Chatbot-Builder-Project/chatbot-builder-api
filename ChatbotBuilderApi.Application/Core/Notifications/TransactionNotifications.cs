using MediatR;

namespace ChatbotBuilderApi.Application.Core.Notifications;

public sealed class TransactionStartNotification : INotification;

public sealed class TransactionSuccessNotification : INotification;

public sealed class TransactionFailureNotification : INotification;

public sealed class TransactionCleanupNotification : INotification;