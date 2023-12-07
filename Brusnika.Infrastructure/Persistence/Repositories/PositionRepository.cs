using Brusnika.Application.Common.Interfaces.Persistence;
using Brusnika.Domain.PositionAggregate;
using Brusnika.Infrastructure.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Brusnika.Infrastructure.Persistence.Repositories;

public class PositionRepository: IPositionRepository
{
    private readonly IMongoCollection<Position> _collection;

    public IMongoQueryable<Position> AsQueryable => _collection.AsQueryable();

    public PositionRepository(IMongoDbContext context, IOptions<MongoDbSettings> settings)
    {
        _collection = context.Database.GetCollection<Position>(settings.Value.PositionsCollectionName);
    }
    
    // public Task<Position> FindOneAsync(StringEntityId id)
    // {
    //     throw new NotImplementedException();
    // }

    public Task<List<Position>> GetAllAsync()
    {
        throw new NotImplementedException();
    }
    
    public async Task InsertOneAsync(Position position)
    {
        await _collection.InsertOneAsync(position);
    }
}