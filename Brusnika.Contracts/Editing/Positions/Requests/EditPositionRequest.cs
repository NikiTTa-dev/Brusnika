namespace Brusnika.Contracts.Editing.Positions.Requests;

public record EditPositionRequest(
    string Id,
    string RoleName,
    string WorkType,
    string Type,
    string? FirstName,
    string? LastName,
    string? Patronymic);