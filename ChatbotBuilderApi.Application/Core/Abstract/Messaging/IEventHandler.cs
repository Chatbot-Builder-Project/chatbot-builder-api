using MediatR;

namespace ChatbotBuilderApi.Application.Core.Abstract.Messaging;

public interface IEventHandler<in TEvent> : INotificationHandler<TEvent>
    where TEvent : INotification;