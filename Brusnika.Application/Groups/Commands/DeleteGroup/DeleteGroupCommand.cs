using Brusnika.Application.Groups.Common;
using MediatR;
using ErrorOr;

namespace Brusnika.Application.Groups.Commands.DeleteGroup;

public record DeleteGroupCommand(
    string Id) 
    : IRequest<ErrorOr<GroupSuccessCommandResult>>;