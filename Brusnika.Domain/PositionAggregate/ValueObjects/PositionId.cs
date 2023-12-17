using Brusnika.Domain.Common.Models;
using MongoDB.Bson;

namespace Brusnika.Domain.PositionAggregate.ValueObjects;

public sealed class PositionId : StringEntityId<PositionId>
{
    private PositionId(string value) : base(value)
    {
    }

    public static PositionId CreateUnique()
    {
        return new PositionId(ObjectId.GenerateNewId().ToString());
    }
    
    public static PositionId Create(string id)
    {
        return new PositionId(id);
    }
}