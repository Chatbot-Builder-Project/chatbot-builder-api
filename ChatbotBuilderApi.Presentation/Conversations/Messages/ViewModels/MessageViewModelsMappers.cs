using ChatbotBuilderApi.Application.Conversations.ListMessages;
using ChatbotBuilderApi.Application.Conversations.SendMessage;
using ChatbotBuilderApi.Application.Core.Shared.Responses;
using ChatbotBuilderApi.Domain.Conversations.ValueObjects;
using ChatbotBuilderApi.Presentation.Graphs.Data;
using Riok.Mapperly.Abstractions;

namespace ChatbotBuilderApi.Presentation.Conversations.Messages.ViewModels;

[Mapper]
public static partial class MessageViewModelsMappers
{
    public static InputMessageViewModel ToViewModel(this InputMessage message)
    {
        return new InputMessageViewModel(
            message.CreatedAt,
            message.Input.Text?.ToModel(),
            message.Input.Option?.ToModel()
        );
    }

    public static OutputMessageViewModel ToViewModel(this OutputMessage message)
    {
        return new OutputMessageViewModel(
            message.CreatedAt,
            message.Output.TextOutput?.ToModel(),
            message.Output.TextExpected,
            message.Output.OptionExpected,
            message.Output.ExpectedOptionMetas?.ToDictionary(
                kvp => kvp.Key.ToModel(),
                kvp => kvp.Value)
        );
    }

    public static SendMessageViewModel ToViewModel(this SendMessageResponse message)
    {
        return new SendMessageViewModel(message.OutputMessage.ToViewModel());
    }

    public static MessageListViewModel ToViewModel(this ListMessagesResponse messages)
    {
        return new MessageListViewModel(
            new PageResponse<InputMessageViewModel>
            {
                TotalCount = messages.InputMessagesPage.TotalCount,
                Items = messages.InputMessagesPage.Items.Select(i => i.ToViewModel()).ToList()
            },
            new PageResponse<OutputMessageViewModel>
            {
                TotalCount = messages.OutputMessagesPage.TotalCount,
                Items = messages.OutputMessagesPage.Items.Select(i => i.ToViewModel()).ToList()
            });
    }
}