namespace Brusnika.Contracts.Editing.Positions.Requests;

public record CreatePositionRequest(
    Guid ParentId,
    Guid RoleId,
    Guid WorkTypeId,
    string Type,
    string? FirstName,
    string? LastName,
    string? Patronymic);