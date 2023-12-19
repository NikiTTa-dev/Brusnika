using Brusnika.Application.Common.Interfaces.Persistence;
using Brusnika.Domain.GroupAggregate;
using Brusnika.Domain.GroupAggregate.ValueObjects;
using Brusnika.Infrastructure.Persistence.Configurations.Common;
using Brusnika.Infrastructure.Persistence.Configurations.Registrars;
using MongoDB.Bson.Serialization;

namespace Brusnika.Infrastructure.Persistence.Configurations.GroupConfigurations;

public class GroupConfiguration : IMongoDbConfiguration
{
    public int Order => 2;
    
    public void Configure()
    {
        EntitiesRegistrar.RegisterEntity<Group, GroupId>();

        BsonClassMap.RegisterClassMap<Group>(cm =>
        {
            cm.AutoMap();
            cm.SetIgnoreExtraElements(true);
        });
    }
}