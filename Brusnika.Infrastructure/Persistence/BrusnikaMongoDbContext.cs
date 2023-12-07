using Brusnika.Application.Common.Interfaces.Persistence;
using Brusnika.Infrastructure.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Brusnika.Infrastructure.Persistence;

public class BrusnikaMongoDbContext : IMongoDbContext
{
    public IMongoDatabase Database { get; }

    public BrusnikaMongoDbContext(IOptions<MongoDbSettings> settings)
    {
        var client = new MongoClient(settings.Value.ConnectionString);
        Database = client.GetDatabase(settings.Value.DatabaseName);
    }
}