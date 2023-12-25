namespace Brusnika.Contracts.Editing.Positions.Requests;

public record AddPositionToGroup(
    string GroupId,
    string PositionId);