namespace Brusnika.Contracts.Editing.Positions.Requests;

public record EditPositionRequest(
    Guid ParentId,
    Guid RoleId,
    Guid WorkTypeId,
    string Type,
    string? FirstName,
    string? LastName,
    string? Patronymic);