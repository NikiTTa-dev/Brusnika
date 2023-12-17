namespace Brusnika.Contracts.Editing.Positions.Requests;

public record AddPositionToGroup(
    Guid GroupId,
    Guid PositionId);