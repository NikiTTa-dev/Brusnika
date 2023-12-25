using Brusnika.Application.Common.Interfaces.Persistence;
using Brusnika.Domain.PositionAggregate;
using Brusnika.Domain.PositionAggregate.ValueObjects;
using Brusnika.Infrastructure.Persistence.Configurations.Common;
using Brusnika.Infrastructure.Settings;
using MediatR;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Brusnika.Infrastructure.Persistence.Repositories;

public class PositionRepository : GenericRepository<Position>, IPositionRepository
{
    public IMongoQueryable<Position> AsQueryable => Collection.AsQueryable();

    public PositionRepository(IMongoDbContext context, IOptions<MongoDbSettings> settings, IPublisher publisher)
        : base(context.Database.GetCollection<Position>(settings.Value.PositionsCollectionName),
            publisher)
    {
    }

    public async Task<Position> FindOneAsync(PositionId id)
    {
        var filter = Builders<Position>.Filter.Eq(p => p.Id, id);
        var position = await Collection.Find(filter).FirstAsync();
        TrackEntity(position);
        return position;
    }

    public async Task UpdateOneAsync(Position position)
    {
        TrackEntity(position);
        await Collection.FindOneAndReplaceAsync(p => position.Id == p.Id, position);
    }

    public async Task<List<Position>> GetAllAsync()
    {
        var positions = await Collection.Find(_ => true).ToListAsync();
        TrackEntities(positions);
        return positions;
    }

    public async Task DeleteAsync(PositionId id)
    {
        var filter = Builders<Position>.Filter.Eq(p => p.Id, id);
        await Collection.DeleteOneAsync(filter);
    }

    public async Task InsertOneAsync(Position position)
    {
        TrackEntity(position);
        await Collection.InsertOneAsync(position);
    }
}