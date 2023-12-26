using Brusnika.Application.Common.Interfaces.Persistence;
using Brusnika.Domain.PositionAggregate.Events;
using MediatR;

namespace Brusnika.Application.Positions.Events;

public class PositionRemovedEventHandler : INotificationHandler<PositionRemoved>
{
    private readonly IPositionRepository _positionRepository;

    public PositionRemovedEventHandler(IPositionRepository positionRepository)
    {
        _positionRepository = positionRepository;
    }
    
    public async Task Handle(PositionRemoved notification, CancellationToken cancellationToken)
    {
        var position = await _positionRepository.FindOneAsync(notification.PositionId);
        if (position.ParentGroupsIds.Contains(notification.GroupId))
            position.RemoveParentGroup(notification.GroupId);
        await _positionRepository.UpdateOneAsync(position);
    }
}