﻿using ChatbotBuilderApi.Application.Core.Abstract.Messaging;
using ChatbotBuilderApi.Application.Core.Notifications;
using FluentValidation;
using MediatR;

namespace ChatbotBuilderApi.DependencyInjection;

public static class ApplicationServicesExtension
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(config =>
            config.RegisterServicesFromAssembly(Application.AssemblyReference.Assembly));

        services.AddValidatorsFromAssembly(Application.AssemblyReference.Assembly);
    }

    /// <summary>
    /// Use this to register an ITransactionHandler,
    /// otherwise MediatR will create a separate transient service each time it handle each notification
    /// </summary>
    internal static void AddScopedTransactionHandler(
        this IServiceCollection services,
        Func<IServiceProvider, ITransactionHandler> implementationFactory)
    {
        services.AddScoped<INotificationHandler<TransactionStartNotification>>(implementationFactory);
        services.AddScoped<INotificationHandler<TransactionSuccessNotification>>(implementationFactory);
        services.AddScoped<INotificationHandler<TransactionFailureNotification>>(implementationFactory);
        services.AddScoped<INotificationHandler<TransactionCleanupNotification>>(implementationFactory);
    }
}