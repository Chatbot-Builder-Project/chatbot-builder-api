using ChatbotBuilderApi.Domain.Core.Abstract;
using MediatR;

namespace ChatbotBuilderApi.Application.Core.Abstract.Messaging;

public interface IDomainEventHandler<in TDomainEvent> : INotificationHandler<TDomainEvent>
    where TDomainEvent : IDomainEvent;