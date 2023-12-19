using Brusnika.Application.Common.Interfaces.Persistence;
using Brusnika.Domain.GroupAggregate.Events;
using MediatR;
using MongoDB.Driver.Linq;

namespace Brusnika.Application.Editing.Events;

public class GroupAddedEventHandler : INotificationHandler<GroupAdded>
{
    private readonly IGroupRepository _groupRepository;

    public GroupAddedEventHandler(IGroupRepository groupRepository)
    {
        _groupRepository = groupRepository;
    }

    public async Task Handle(GroupAdded notification, CancellationToken cancellationToken)
    {
        var group = await _groupRepository.AsQueryable
            .FirstOrDefaultAsync(g => g.Id == notification.ChildGroupId, cancellationToken);
        if (!group.ParentGroupsIds.Contains(notification.ParentGroupId))
            group.AddParentGroup(notification.ParentGroupId);
        await _groupRepository.UpdateOneAsync(group);
    }
}