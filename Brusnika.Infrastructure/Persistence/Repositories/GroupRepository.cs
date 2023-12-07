using Brusnika.Application.Common.Interfaces.Persistence;
using Brusnika.Domain.GroupAggregate;
using Brusnika.Infrastructure.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Brusnika.Infrastructure.Persistence.Repositories;

public class GroupRepository: IGroupRepository
{
    private readonly IMongoCollection<Group> _collection;

    public IMongoQueryable<Group> AsQueryable => _collection.AsQueryable();
    
    public GroupRepository(IMongoDbContext context, IOptions<MongoDbSettings> settings)
    {
        _collection = context.Database.GetCollection<Group>(settings.Value.GroupsCollectionName);
    }
    
    public async Task InsertOneAsync(Group group)
    {
        await _collection.InsertOneAsync(group);
    }

    // public Task<Group> FindOneAsync(StringEntityId id)
    // {
    //     throw new NotImplementedException();
    // }

    public Task<List<Group>> GetAllAsync()
    {
        throw new NotImplementedException();
    }
}