using Brusnika.Application.Positions.Common;
using ErrorOr;
using MediatR;

namespace Brusnika.Application.Positions.Commands.AddPosition;

public record AddPositionCommand(
    string GroupId,
    string PositionId)
    : IRequest<ErrorOr<PositionSuccessCommandResult>>;