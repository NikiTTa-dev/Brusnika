using MediatR;
using ErrorOr;

namespace Brusnika.Application.Groups.Commands.CreateGroup;

public record CreateGroupCommand(
    string CategoryName,
    string Name) 
    : IRequest<ErrorOr<CreateGroupCommandResult>>;