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

    private List<PositionId> _positionIdsIds = new();

    public IReadOnlyCollection<PositionId> PositionsIds
    {
        get => _positionIdsIds;
        private set => _positionIdsIds = value.ToList();
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
        _positionIdsIds.Add(positionId);
    }

    public void AddChildGroup(GroupId groupId)
    {
        AddDomainEvent(new GroupAdded(Id, groupId));
        _childGroupIds.Add(groupId);
    }

    public void RemoveChildGroup(GroupId groupId)
    {
        if (_childGroupIds.Contains(groupId))
        {
            _childGroupIds.Remove(groupId);
            AddDomainEvent(new GroupRemoved(Id, groupId));
        }
    }

    public void AddParentGroup(GroupId groupId)
    {
        _parentGroupIds.Add(groupId);
    }

    public void RemoveParentGroup(GroupId groupId)
    {
        if (_parentGroupIds.Contains(groupId))
            _parentGroupIds.Remove(groupId);
    }
    
    public void UpdateName(string title, string categoryName)
    {
        Title = title;
        CategoryName = categoryName;
        UpdatedAt = DateTime.UtcNow;
    }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public Group()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {
    }
}