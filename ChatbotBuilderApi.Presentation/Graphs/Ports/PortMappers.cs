using ChatbotBuilderApi.Application.Graphs.Ports.InputPorts;
using ChatbotBuilderApi.Application.Graphs.Ports.OutputPorts;
using ChatbotBuilderApi.Presentation.Graphs.Metas;
using Riok.Mapperly.Abstractions;

namespace ChatbotBuilderApi.Presentation.Graphs.Ports;

[Mapper]
public static partial class PortMappers
{
    public static InputPortModel ToModel(this InputPortDto dto)
    {
        return new InputPortModel(
            dto.Info.ToModel(),
            dto.Visual.ToModel(),
            dto.NodeIdentifier,
            dto.DataType);
    }

    public static InputPortDto ToDto(this InputPortModel model)
    {
        return new InputPortDto(
            model.Info.ToDomain(),
            model.Visual.ToDomain(),
            model.NodeId,
            model.DataType);
    }

    public static OutputPortModel ToModel(this OutputPortDto dto)
    {
        return new OutputPortModel(
            dto.Info.ToModel(),
            dto.Visual.ToModel(),
            dto.NodeIdentifier,
            dto.DataType);
    }

    public static OutputPortDto ToDto(this OutputPortModel model)
    {
        return new OutputPortDto(
            model.Info.ToDomain(),
            model.Visual.ToDomain(),
            model.NodeId,
            model.DataType);
    }
}