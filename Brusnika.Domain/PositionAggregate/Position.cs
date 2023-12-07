using Brusnika.Domain.Common.Models;
using Brusnika.Domain.PositionAggregate.ValueObjects;

namespace Brusnika.Domain.PositionAggregate;

public class Position : AggregateRoot<PositionId>
{
    public string Name { get; private set; }
    
    private Position(string name)
    {
        Name = name;
    }

    public static Position Create(string name)
    {
        return new Position(name);
    }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public Position()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {
    }
}