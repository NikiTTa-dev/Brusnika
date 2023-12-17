using Brusnika.Domain.Common.Models;
using Brusnika.Domain.GroupAggregate.ValueObjects;
using Brusnika.Domain.PositionAggregate.ValueObjects;

namespace Brusnika.Domain.GroupAggregate;

public sealed class Group : AggregateRoot<GroupId>
{
    public string Title { get; private set; }
    public string CategoryName { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }
    public GroupId? GroupId { get; private set; }


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

    private Group(
        GroupId id,
        string title,
        string categoryName,
        DateTime createdAt, 
        DateTime updatedAt,
        GroupId? groupId)
    {
        Id = id;
        Title = title;
        CategoryName = categoryName;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        GroupId = groupId;
    }

    public static Group Create(string title, string categoryName, GroupId? groupId)
    {
        return new Group(GroupId.CreateUnique(), title, categoryName, DateTime.UtcNow, DateTime.UtcNow, groupId);
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