// using Brusnika.Application.Common.Interfaces.Persistence;
// using Brusnika.Domain.Common.Models;
// using Brusnika.Infrastructure.Persistence.Generators;
// using MongoDB.Bson.Serialization;
//
// namespace Brusnika.Infrastructure.Persistence.Configurations.Common;
//
// public class EntityConfiguration : IMongoDbConfiguration
// {
//     public int Order => 1;
//
//     public void Configure()
//     {
//         BsonClassMap.RegisterClassMap<Entity<StringEntityId<>>>(cm =>
//         {
//             cm.SetIsRootClass(true);
//             cm.MapIdProperty(c => c.Id)
//                 .SetSerializer(BsonSerializer.LookupSerializer<StringEntityId>())
//                 .SetIdGenerator(StringEntityIdGenerator.Instance)
//                 .SetIgnoreIfNull(true);
//         });
//     }
// }