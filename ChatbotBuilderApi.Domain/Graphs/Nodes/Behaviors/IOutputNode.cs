﻿using ChatbotBuilderApi.Domain.Graphs.Ports;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Ids;

namespace ChatbotBuilderApi.Domain.Graphs.Nodes.Behaviors;

/// <summary>
/// A node that has outputs and can publish them to other nodes.
/// </summary>
public interface IOutputNode
{
    IEnumerable<Port<OutputPortId>> GetOutputPorts();
    void PublishOutputs();
}