using Brusnika.Application.Common.Interfaces.Persistence;
using Brusnika.Domain.PositionAggregate;
using Brusnika.Infrastructure.Persistence.Configurations.Common;
using Brusnika.Infrastructure.Settings;
using MediatR;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Brusnika.Infrastructure.Persistence.Repositories;

public class PositionRepository: GenericRepository<Position>, IPositionRepository
{
    public IMongoQueryable<Position> AsQueryable => Collection.AsQueryable();

    public PositionRepository(IMongoDbContext context, IOptions<MongoDbSettings> settings, IPublisher publisher) 
        : base(context.Database.GetCollection<Position>(settings.Value.PositionsCollectionName),
            publisher)
    {
    }
    
    // public Task<Position> FindOneAsync(StringEntityId id)
    // {
    //     throw new NotImplementedException();
    // }

    public async Task UpdateOneAsync(Position position)
    {
        TrackEntity(position);
        await Collection.FindOneAndReplaceAsync(p => position.Id == p.Id, position);
    }

    public Task<List<Position>> GetAllAsync()
    {
        throw new NotImplementedException();
    }
    
    public async Task InsertOneAsync(Position position)
    {
        TrackEntity(position);
        await Collection.InsertOneAsync(position);
    }
}