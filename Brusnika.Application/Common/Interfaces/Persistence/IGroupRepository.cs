using Brusnika.Domain.GroupAggregate;
using MongoDB.Driver.Linq;

namespace Brusnika.Application.Common.Interfaces.Persistence;

public interface IGroupRepository
{
    IMongoQueryable<Group> AsQueryable { get; }
    Task InsertOneAsync(Group group);
    //Task<Group> FindOneAsync(StringEntityId id);
    Task<List<Group>> GetAllAsync();
}