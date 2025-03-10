﻿using ChatbotBuilderApi.Application.Conversations.GetConversation;
using ChatbotBuilderApi.Application.Conversations.ListConversations;
using ChatbotBuilderApi.Application.Conversations.StartConversation;
using ChatbotBuilderApi.Presentation.Conversations.Messages.ViewModels;
using Riok.Mapperly.Abstractions;

namespace ChatbotBuilderApi.Presentation.Conversations.ViewModels;

[Mapper]
public static partial class ConversationViewModelsMappers
{
    public static partial ConversationViewModel ToViewModel(this GetConversationResponse conversation);

    public static partial ConversationListViewModel ToViewModel(this ListConversationsResponse conversations);

    public static StartConversationViewModel ToViewModel(this StartConversationResponse conversation)
    {
        return new StartConversationViewModel(
            conversation.ConversationId,
            conversation.InitialMessage.ToViewModel());
    }
}