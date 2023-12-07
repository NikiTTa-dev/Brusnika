using Brusnika.Domain.Common.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;

namespace Brusnika.Infrastructure.Persistence.Generators;

public class StringEntityIdGenerator<TEntity, TId> : IIdGenerator
    where TEntity : Entity<TId>
    where TId : StringEntityId<TId>
{
    public static StringEntityIdGenerator<TEntity, TId> Instance { get; } = new();

    public object GenerateId(object container, object document)
    {
        var id = ObjectId.GenerateNewId().ToString();
        var res = typeof(TId)
            .GetMethod("Create")?
            .Invoke(null, new object?[] { id }) as TId;
        
        if (res == null)
            throw new InvalidOperationException($"No static method Create registered for {typeof(TId)}");

        return res;
    }

    public bool IsEmpty(object id)
    {
        var typedId = id as TId;
        return string.IsNullOrEmpty(typedId?.Value);
    }
}