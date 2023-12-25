namespace Brusnika.Contracts.Editing.Positions.Requests;

public record RemovePositionFromGroup(
    string GroupId,
    string PositionId);