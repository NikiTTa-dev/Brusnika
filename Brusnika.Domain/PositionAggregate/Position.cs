using Brusnika.Domain.Common.Models;
using Brusnika.Domain.GroupAggregate.ValueObjects;
using Brusnika.Domain.PositionAggregate.ValueObjects;

namespace Brusnika.Domain.PositionAggregate;

public class Position : AggregateRoot<PositionId>
{
    public string Name { get; private set; }
    public string Type { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }
    public string WorkType { get; private set; }
    public string? FirstName { get; private set; }
    public string? LastName { get; private set; }
    public string? Patronymic { get; private set; }
    
    private List<GroupId> _parentGroupIds = new();
    public IReadOnlyCollection<GroupId> ParentGroupsIds
    {
        get => _parentGroupIds;
        private set => _parentGroupIds = value.ToList();
    }
    
    private Position(
        PositionId id,
        string name,
        string type,
        string workType, 
        string? firstName,
        string? lastName, 
        string? patronymic, 
        DateTime createdAt,
        DateTime updatedAt)
    {
        Id = id;
        Name = name;
        Type = type;
        WorkType = workType;
        FirstName = firstName;
        LastName = lastName;
        Patronymic = patronymic;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public static Position Create(
        string name,
        string type,
        string workType, 
        string? firstName,
        string? lastName, 
        string? patronymic)
    {
        return new Position(
            PositionId.CreateUnique(),
            name,
            type,
            workType,
            firstName,
            lastName,
            patronymic,
            DateTime.UtcNow, 
            DateTime.UtcNow);
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

    public void UpdateFields(
        string name,
        string type,
        string workType, 
        string? firstName,
        string? lastName, 
        string? patronymic)
    {
        Name = name;
        Type = type;
        WorkType = workType;
        FirstName = firstName;
        LastName = lastName;
        Patronymic = patronymic;
        UpdatedAt = DateTime.UtcNow;
    }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public Position()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {
    }
}