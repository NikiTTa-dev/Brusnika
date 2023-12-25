using Brusnika.Application.Common.Interfaces.Persistence;
using Brusnika.Domain.GroupAggregate;
using Brusnika.Domain.GroupAggregate.ValueObjects;
using Brusnika.Infrastructure.Persistence.Configurations.Common;
using Brusnika.Infrastructure.Settings;
using MediatR;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Brusnika.Infrastructure.Persistence.Repositories;

public class GroupRepository : GenericRepository<Group>, IGroupRepository
{
    public IMongoQueryable<Group> AsQueryable => Collection.AsQueryable();

    public GroupRepository(IMongoDbContext context, IOptions<MongoDbSettings> settings, IPublisher publisher)
        : base(
            context.Database.GetCollection<Group>(settings.Value.GroupsCollectionName),
            publisher)
    {
    }

    public async Task InsertOneAsync(Group group)
    {
        TrackEntity(group);
        //if (group.GetType().IsAssignableFrom())
        await Collection.InsertOneAsync(group);
    }

    public async Task UpdateOneAsync(Group group)
    {
        TrackEntity(group);
        await Collection.FindOneAndReplaceAsync(p => group.Id == p.Id, group);
    }

    public async Task<Group> FindOneAsync(GroupId id)
    {
        var filter = Builders<Group>.Filter.Eq(p => p.Id, id);
        var group = await Collection.Find(filter).FirstAsync();
        TrackEntity(group);
        return group;
    }

    public async Task<List<Group>> GetAllAsync()
    {
        var groups = await Collection.Find(_ => true).ToListAsync();
        TrackEntities(groups);
        return groups;
    }

    public async Task DeleteAsync(GroupId id)
    {
        var filter = Builders<Group>.Filter.Eq(p => p.Id, id);
        await Collection.DeleteOneAsync(filter);
    }
}