using Brusnika.Application.Common.Interfaces.Persistence;
using Brusnika.Domain.GroupAggregate.Events;
using MediatR;

namespace Brusnika.Application.Groups.Events;

public class GroupRemovedEventHandler : INotificationHandler<GroupRemoved>
{
    private readonly IGroupRepository _groupRepository;

    public GroupRemovedEventHandler(IGroupRepository groupRepository)
    {
        _groupRepository = groupRepository;
    }
    
    public async Task Handle(GroupRemoved notification, CancellationToken cancellationToken)
    {
        var group = await _groupRepository.FindOneAsync(notification.ChildGroupId);
        if (group.ParentGroupsIds.Contains(notification.ParentGroupId))
            group.RemoveParentGroup(notification.ParentGroupId);
        await _groupRepository.UpdateOneAsync(group);
    }
}