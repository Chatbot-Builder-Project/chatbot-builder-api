﻿using ChatbotBuilderApi.Domain.Core.Primitives;

namespace ChatbotBuilderApi.Domain.Graphs.ValueObjects.Ids;

public sealed class EnumId : EntityId<EnumId>
{
    public EnumId(Guid value) : base(value)
    {
    }
}