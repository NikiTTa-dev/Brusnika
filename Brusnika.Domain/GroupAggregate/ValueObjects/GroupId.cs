using Brusnika.Domain.Common.Models;
using MongoDB.Bson;

namespace Brusnika.Domain.GroupAggregate.ValueObjects;

public sealed class GroupId : StringEntityId<GroupId>
{
    private GroupId(string value) : base(value)
    {
    }

    public static GroupId CreateUnique()
    {
        return new GroupId(ObjectId.GenerateNewId().ToString());
    }
    
    public static GroupId Create(string id)
    {
        return new GroupId(id);
    }
}