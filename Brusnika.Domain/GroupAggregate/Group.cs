using Brusnika.Domain.Common.Models;
using Brusnika.Domain.GroupAggregate.Events;
using Brusnika.Domain.GroupAggregate.ValueObjects;
using Brusnika.Domain.PositionAggregate.Events;
using Brusnika.Domain.PositionAggregate.ValueObjects;

namespace Brusnika.Domain.GroupAggregate;

public sealed class Group : AggregateRoot<GroupId>
{
    public string Title { get; private set; }
    public string CategoryName { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }
    
    private List<GroupId> _parentGroupIds = new();
    public IReadOnlyCollection<GroupId> ParentGroupsIds
    {
        get => _parentGroupIds;
        private set => _parentGroupIds = value.ToList();
    }
    
    private List<GroupId> _childGroupIds = new();
    public IReadOnlyCollection<GroupId> ChildGroupsIds
    {
        get => _childGroupIds;
        private set => _childGroupIds = value.ToList();
    }
    
    private List<PositionId> _positionIds = new();
    public IReadOnlyCollection<PositionId> Positions
    {
        get => _positionIds;
        private set => _positionIds = value.ToList();
    }

    private Group(
        GroupId id,
        string title,
        string categoryName,
        DateTime createdAt, 
        DateTime updatedAt)
    {
        Id = id;
        Title = title;
        CategoryName = categoryName;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public static Group Create(string title, string categoryName)
    {
        return new Group(GroupId.CreateUnique(), title, categoryName, DateTime.UtcNow, DateTime.UtcNow);
    }

    public void AddPosition(PositionId positionId)
    {
        AddDomainEvent(new PositionAdded(Id, positionId));
        _positionIds.Add(positionId);
    }

    public void AddChildGroup(GroupId groupId)
    {
        AddDomainEvent(new GroupAdded(Id, groupId));
        _childGroupIds.Add(groupId);
    }
    
    public void AddParentGroup(GroupId groupId)
    {
        _parentGroupIds.Add(groupId);
    }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public Group()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {
    }
}