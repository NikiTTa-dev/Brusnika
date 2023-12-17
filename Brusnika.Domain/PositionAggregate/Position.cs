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
    public GroupId? GroupId { get; private set; }
    
    
    private Position(
        PositionId id,
        string name,
        string type,
        string workType, 
        string? firstName,
        string? lastName, 
        string? patronymic, 
        GroupId? groupId,
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
        GroupId = groupId;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public static Position Create(
        string name,
        string type,
        string workType, 
        string? firstName,
        string? lastName, 
        string? patronymic, 
        GroupId? groupId)
    {
        return new Position(
            PositionId.CreateUnique(),
            name,
            type,
            workType,
            firstName,
            lastName,
            patronymic,
            groupId,
            DateTime.UtcNow, 
            DateTime.UtcNow);
    }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public Position()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {
    }
}