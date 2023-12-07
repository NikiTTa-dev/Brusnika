using Brusnika.Domain.Common.Models;
using Brusnika.Infrastructure.Persistence.Generators;
using Brusnika.Infrastructure.Persistence.Serializers;
using MongoDB.Bson.Serialization;

namespace Brusnika.Infrastructure.Persistence.Configurations.Registrars;

public class EntitiesRegistrar
{
    public static void RegisterEntity<TEntity, TId>()
        where TEntity : Entity<TId>
        where TId : StringEntityId<TId>
    {
        BsonClassMap.TryRegisterClassMap<Entity<TId>>(cm =>
        {
            cm.SetIsRootClass(true);
            cm.MapIdProperty(c => c.Id)
                .SetSerializer(StringEntityIdSerializer<TId>.Instance)
                .SetIdGenerator(StringEntityIdGenerator<TEntity, TId>.Instance)
                .SetIgnoreIfNull(true);
        });
    }
}