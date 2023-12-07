using MongoDB.Driver;

namespace Brusnika.Application.Common.Interfaces.Persistence;

public interface IMongoDbContext
{ 
    IMongoDatabase Database { get; }
}