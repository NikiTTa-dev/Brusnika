using Brusnika.Application.Common.Interfaces.Persistence;
using Brusnika.Domain.GroupAggregate;
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

    // public Task<Group> FindOneAsync(StringEntityId id)
    // {
    //     throw new NotImplementedException();
    // }

    public Task<List<Group>> GetAllAsync()
    {
        throw new NotImplementedException();
    }
}