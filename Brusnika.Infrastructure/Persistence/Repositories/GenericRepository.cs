using Brusnika.Application.Common.Interfaces.Persistence;
using Brusnika.Domain.Common.Models;
using MediatR;
using MongoDB.Driver;

namespace Brusnika.Infrastructure.Persistence.Repositories;

public abstract class GenericRepository<TDocument> : IGenericRepository<TDocument>
    where TDocument : IHasDomainEvents
{
    protected IMongoCollection<TDocument> Collection { get; }
    protected List<IHasDomainEvents> TrackedEntities { get; } = new();
    private readonly IPublisher _publisher;

    protected GenericRepository(
        IMongoCollection<TDocument> collection,
        IPublisher publisher)
    {
        _publisher = publisher;
        Collection = collection;
    }

    public virtual async Task PublishDomainEvents()
    {
        foreach (var trackedEntity in TrackedEntities.ToList())
        {
            if (!trackedEntity.DomainEvents.Any())
                continue;
            foreach (var domainEvent in trackedEntity.DomainEvents)
            {
                await _publisher.Publish(domainEvent);
            }
        }
    }

    protected virtual void TrackEntity(TDocument entity)
    {
        TrackedEntities.Add(entity);
    }
}