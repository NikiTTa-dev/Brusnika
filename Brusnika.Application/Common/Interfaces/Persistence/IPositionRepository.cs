using Brusnika.Domain.PositionAggregate;
using MongoDB.Driver.Linq;

namespace Brusnika.Application.Common.Interfaces.Persistence;

public interface IPositionRepository : IGenericRepository<Position>
{
    IMongoQueryable<Position> AsQueryable { get; }
    Task InsertOneAsync(Position position);
    Task UpdateOneAsync(Position position);

    //Task<Position> FindOneAsync(StringEntityId id);
    Task<List<Position>> GetAllAsync();
}