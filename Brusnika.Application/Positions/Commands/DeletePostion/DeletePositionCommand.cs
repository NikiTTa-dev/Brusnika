using Brusnika.Application.Positions.Common;
using ErrorOr;
using MediatR;

namespace Brusnika.Application.Positions.Commands.DeletePostion;

public record DeletePositionCommand(
    string PositionId)
    : IRequest<ErrorOr<PositionSuccessCommandResult>>;