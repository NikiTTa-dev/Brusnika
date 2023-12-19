using MongoDB.Driver;

namespace Brusnika.Infrastructure.Persistence.Configurations.Common;

public interface IMongoDbContext
{ 
    IMongoDatabase Database { get; }
    MongoClient Client { get; }
}