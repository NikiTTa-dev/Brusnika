using Brusnika.Application.Common.Interfaces.Persistence;
using Brusnika.Domain.PositionAggregate.Events;
using MediatR;
using MongoDB.Driver.Linq;

namespace Brusnika.Application.Positions.Events;

public class PositionAddedEventHandler : INotificationHandler<PositionAdded>
{
    private readonly IPositionRepository _positionRepository;

    public PositionAddedEventHandler(IPositionRepository positionRepository)
    {
        _positionRepository = positionRepository;
    }

    public async Task Handle(PositionAdded notification, CancellationToken cancellationToken)
    {
        var position = await _positionRepository.AsQueryable
            .FirstOrDefaultAsync(g => g.Id == notification.PositionId, cancellationToken);
        if (!position.ParentGroupsIds.Contains(notification.GroupId))
            position.AddParentGroup(notification.GroupId);
        await _positionRepository.UpdateOneAsync(position);
    }
}