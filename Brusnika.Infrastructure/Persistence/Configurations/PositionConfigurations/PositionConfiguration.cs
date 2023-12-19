using Brusnika.Application.Common.Interfaces.Persistence;
using Brusnika.Domain.PositionAggregate;
using Brusnika.Domain.PositionAggregate.ValueObjects;
using Brusnika.Infrastructure.Persistence.Configurations.Common;
using Brusnika.Infrastructure.Persistence.Configurations.Registrars;
using MongoDB.Bson.Serialization;

namespace Brusnika.Infrastructure.Persistence.Configurations.PositionConfigurations;

public class PositionConfiguration : IMongoDbConfiguration
{
    public int Order => 2;
    
    public void Configure()
    {
        EntitiesRegistrar.RegisterEntity<Position, PositionId>();

        BsonClassMap.RegisterClassMap<Position>(cm =>
        {
            cm.AutoMap();
            cm.SetIgnoreExtraElements(true);
        });
    }
}