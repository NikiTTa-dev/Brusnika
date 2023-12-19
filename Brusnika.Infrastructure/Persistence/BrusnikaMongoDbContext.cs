using Brusnika.Infrastructure.Persistence.Configurations.Common;
using Brusnika.Infrastructure.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Brusnika.Infrastructure.Persistence;

public class BrusnikaMongoDbContext : IMongoDbContext
{
    public IMongoDatabase Database { get; }
    public MongoClient Client { get; }

    public BrusnikaMongoDbContext(IOptions<MongoDbSettings> settings)
    {
        Client = new MongoClient(settings.Value.ConnectionString);
        Database = Client.GetDatabase(settings.Value.DatabaseName);
    }
}