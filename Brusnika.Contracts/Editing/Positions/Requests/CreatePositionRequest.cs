namespace Brusnika.Contracts.Editing.Positions.Requests;

public record CreatePositionRequest(
    string ParentId,
    string RoleName,
    string WorkType,
    string Type,
    string? FirstName,
    string? LastName,
    string? Patronymic);