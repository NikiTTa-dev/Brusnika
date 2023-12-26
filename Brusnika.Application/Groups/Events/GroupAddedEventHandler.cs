using Brusnika.Application.Common.Interfaces.Persistence;
using Brusnika.Domain.GroupAggregate.Events;
using MediatR;

namespace Brusnika.Application.Groups.Events;

public class GroupAddedEventHandler : INotificationHandler<GroupAdded>
{
    private readonly IGroupRepository _groupRepository;

    public GroupAddedEventHandler(IGroupRepository groupRepository)
    {
        _groupRepository = groupRepository;
    }

    public async Task Handle(GroupAdded notification, CancellationToken cancellationToken)
    {
        var group = await _groupRepository.FindOneAsync(notification.ChildGroupId);
        if (!group.ParentGroupsIds.Contains(notification.ParentGroupId))
            group.AddParentGroup(notification.ParentGroupId);
        await _groupRepository.UpdateOneAsync(group);
    }
}