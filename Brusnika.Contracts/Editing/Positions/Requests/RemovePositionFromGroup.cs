namespace Brusnika.Contracts.Editing.Positions.Requests;

public record RemovePositionFromGroup(
    Guid GroupId,
    Guid PositionId);