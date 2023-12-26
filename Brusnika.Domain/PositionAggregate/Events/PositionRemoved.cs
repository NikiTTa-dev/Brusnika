using Brusnika.Domain.Common.Models;
using Brusnika.Domain.GroupAggregate.ValueObjects;
using Brusnika.Domain.PositionAggregate.ValueObjects;

namespace Brusnika.Domain.PositionAggregate.Events;

public record PositionRemoved(
    GroupId GroupId,
    PositionId PositionId)
    : IDomainEvent;