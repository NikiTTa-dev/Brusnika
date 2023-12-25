using Brusnika.Application.Groups.Common;
using MediatR;
using ErrorOr;

namespace Brusnika.Application.Groups.Commands.CreateGroup;

public record CreateGroupCommand(
    string CategoryName,
    string Name) 
    : IRequest<ErrorOr<CreateGroupCommandResult>>;