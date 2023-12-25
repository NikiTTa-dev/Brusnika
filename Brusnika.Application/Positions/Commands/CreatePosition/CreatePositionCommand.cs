using ErrorOr;
using MediatR;

namespace Brusnika.Application.Positions.Commands.CreatePostion;

public record CreatePositionCommand(
    string ParentId,
    string RoleName,
    string WorkType,
    string Type,
    string? FirstName,
    string? LastName,
    string? Patronymic)
    : IRequest<ErrorOr<CreatePositionCommandResult>>;