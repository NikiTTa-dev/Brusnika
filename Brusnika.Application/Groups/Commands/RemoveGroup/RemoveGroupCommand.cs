using Brusnika.Application.Groups.Common;
using MediatR;
using ErrorOr;

namespace Brusnika.Application.Groups.Commands.RemoveGroup;

public record RemoveGroupCommand(
    string ParentId,
    string ChildId)
    : IRequest<ErrorOr<GroupSuccessCommandResult>>;