using Brusnika.Domain.PositionAggregate;
using Brusnika.Domain.PositionAggregate.ValueObjects;
using MongoDB.Driver.Linq;

namespace Brusnika.Application.Common.Interfaces.Persistence;

public interface IPositionRepository : IGenericRepository<Position>
{
    IMongoQueryable<Position> AsQueryable { get; }
    Task InsertOneAsync(Position position);
    Task UpdateOneAsync(Position position);

    Task<Position> FindOneAsync(PositionId id);
    Task<List<Position>> GetAllAsync();
    Task DeleteAsync(PositionId id);
}