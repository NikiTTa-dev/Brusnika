using Brusnika.Application.Positions.Common;
using ErrorOr;
using MediatR;

namespace Brusnika.Application.Positions.Commands.EditPosition;

public record EditPositionCommand(
    string Id,
    string RoleName,
    string WorkType,
    string Type,
    string? FirstName,
    string? LastName,
    string? Patronymic)
    : IRequest<ErrorOr<PositionSuccessCommandResult>>;