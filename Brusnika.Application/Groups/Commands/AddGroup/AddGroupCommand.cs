using Brusnika.Application.Groups.Common;
using ErrorOr;
using MediatR;

namespace Brusnika.Application.Groups.Commands.AddGroup;

public record AddGroupCommand(
    string ParentId,
    string ChildId)
    : IRequest<ErrorOr<GroupSuccessCommandResult>>; 