using Brusnika.Domain.Common.Models;
using Brusnika.Domain.GroupAggregate.ValueObjects;

namespace Brusnika.Domain.GroupAggregate.Events;

public record GroupAdded(
    GroupId ParentGroupId,
    GroupId ChildGroupId) : IDomainEvent;