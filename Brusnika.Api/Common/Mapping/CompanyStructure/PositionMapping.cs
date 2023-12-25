using Brusnika.Application.Positions.Commands.AddPosition;
using Brusnika.Application.Positions.Commands.CreatePostion;
using Brusnika.Application.Positions.Commands.DeletePostion;
using Brusnika.Application.Positions.Commands.EditPostion;
using Brusnika.Application.Positions.Commands.RemovePosition;
using Brusnika.Contracts.Editing.Positions.Requests;
using Brusnika.Contracts.Editing.Positions.Responses;
using Mapster;

namespace Brusnika.Api.Common.Mapping.CompanyStructure;

public class PositionMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreatePositionRequest, CreatePositionCommand>();
        config.NewConfig<CreatePositionCommandResult, CreatePositionResponse>();

        config.NewConfig<EditPositionRequest, EditPositionCommand>();
        config.NewConfig<DeletePositionRequest, DeletePositionCommand>();
        config.NewConfig<AddPositionToGroup, AddPositionCommand>();
        config.NewConfig<RemovePositionFromGroup, RemovePositionCommand>();
    }
}