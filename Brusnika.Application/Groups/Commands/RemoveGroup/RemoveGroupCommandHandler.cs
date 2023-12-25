using Brusnika.Application.Common.Interfaces.Persistence;
using Brusnika.Application.Groups.Common;
using Brusnika.Domain.GroupAggregate.ValueObjects;
using ErrorOr;
using MediatR;

namespace Brusnika.Application.Groups.Commands.RemoveGroup;

public class RemoveGroupCommandHandler : IRequestHandler<RemoveGroupCommand, ErrorOr<GroupSuccessCommandResult>>
{
    private readonly IGroupRepository _groupRepository;

    public RemoveGroupCommandHandler(IGroupRepository groupRepository)
    {
        _groupRepository = groupRepository;
    }
    
    public async Task<ErrorOr<GroupSuccessCommandResult>> Handle(RemoveGroupCommand request, CancellationToken cancellationToken)
    {
        var parentGroup = await _groupRepository.FindOneAsync(GroupId.Create(request.ParentId));
        parentGroup.RemoveChildGroup(GroupId.Create(request.ChildId));

        await _groupRepository.UpdateOneAsync(parentGroup);
        await _groupRepository.PublishDomainEvents();

        return new GroupSuccessCommandResult();
    }
}