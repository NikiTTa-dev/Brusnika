using Brusnika.Application.Positions.Common;
using ErrorOr;
using MediatR;

namespace Brusnika.Application.Positions.Commands.RemovePosition;

public record RemovePositionCommand(
    string GroupId,
    string PositionId)
    : IRequest<ErrorOr<PositionSuccessCommandResult>>;