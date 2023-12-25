using Brusnika.Application.Common.Interfaces.Persistence;
using Brusnika.Domain.GroupAggregate;
using ErrorOr;
using MediatR;

namespace Brusnika.Application.Groups.Commands.CreateGroup;

public class CreateGroupCommandHandler : IRequestHandler<CreateGroupCommand, ErrorOr<CreateGroupCommandResult>>
{
    private readonly IGroupRepository _groupRepository;

    public CreateGroupCommandHandler(IGroupRepository groupRepository)
    {
        _groupRepository = groupRepository;
    }
    
    public async Task<ErrorOr<CreateGroupCommandResult>> Handle(CreateGroupCommand request, CancellationToken cancellationToken)
    {
        var group = Group.Create(request.Name, request.CategoryName);
        await _groupRepository.InsertOneAsync(group);
        await _groupRepository.PublishDomainEvents();

        return new CreateGroupCommandResult(group.Id.Value);
    }
}