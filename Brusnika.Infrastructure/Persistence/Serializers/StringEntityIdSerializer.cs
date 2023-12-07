using Brusnika.Domain.Common.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace Brusnika.Infrastructure.Persistence.Serializers;

public class StringEntityIdSerializer<TId> : SerializerBase<TId>
    where TId : StringEntityId<TId>
{
    public static StringEntityIdSerializer<TId> Instance { get; } = new();

    private readonly StringSerializer _stringSerializer = new(BsonType.ObjectId);

    public override TId Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
    {
        var id = _stringSerializer.Deserialize(context, args);
        var res = typeof(TId)
            .GetMethod("Create")?
            .Invoke(null, new object?[] { id }) as TId;

        if (res == null)
            throw new InvalidOperationException($"No static method Create registered for {typeof(TId)}");

        return res;
    }

    public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, TId? value)
        => _stringSerializer.Serialize(context, args, value?.Value);
}