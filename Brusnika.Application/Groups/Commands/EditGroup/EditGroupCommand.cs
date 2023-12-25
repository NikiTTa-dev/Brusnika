using Brusnika.Application.Groups.Common;
using MediatR;
using ErrorOr;

namespace Brusnika.Application.Groups.Commands.EditGroup;

public record EditGroupCommand(
    string Id,
    string CategoryName,
    string Name)
    : IRequest<ErrorOr<GroupSuccessCommandResult>>;