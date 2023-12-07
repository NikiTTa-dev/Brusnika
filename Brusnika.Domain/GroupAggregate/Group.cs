using Brusnika.Domain.Common.Models;
using Brusnika.Domain.GroupAggregate.ValueObjects;
using Brusnika.Domain.PositionAggregate.ValueObjects;

namespace Brusnika.Domain.GroupAggregate;

public sealed class Group : AggregateRoot<GroupId>
{
    public string GroupName { get; private set; }
    
    private List<PositionId> _positionIds = new();
    public IReadOnlyCollection<PositionId> Positions
    {
        get => _positionIds;
        private set => _positionIds = value.ToList();
    }
    
    private List<GroupId> _groupIds = new();
    public IReadOnlyCollection<GroupId> Groups
    {
        get => _groupIds;
        private set => _groupIds = value.ToList();
    }
    
    private Group(GroupId id, string groupName)
    {
        Id = id;
        GroupName = groupName;
    }

    public static Group Create(string name)
    {
        return new Group(GroupId.Create(null), name);
    }

    public void AddPosition(PositionId position)
    {
        _positionIds.Add(position);
    }

    public void AddGroup(GroupId group)
    {
        _groupIds.Add(group);
    }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public Group()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {
    }
}