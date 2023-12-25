using Brusnika.Application.Positions.Common;
using MediatR;
using ErrorOr;

namespace Brusnika.Application.Positions.Commands.EditPostion;

public record EditPositionCommand(
    string ParentId,
    string RoleName,
    string WorkType,
    string Type,
    string? FirstName,
    string? LastName,
    string? Patronymic)
    : IRequest<ErrorOr<PositionSuccessCommandResult>>;