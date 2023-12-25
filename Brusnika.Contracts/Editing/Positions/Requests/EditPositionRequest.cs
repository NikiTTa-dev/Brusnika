namespace Brusnika.Contracts.Editing.Positions.Requests;

public record EditPositionRequest(
    string ParentId,
    string RoleName,
    string WorkType,
    string Type,
    string? FirstName,
    string? LastName,
    string? Patronymic);