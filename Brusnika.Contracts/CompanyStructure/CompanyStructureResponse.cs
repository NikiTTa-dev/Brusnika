namespace Brusnika.Contracts.CompanyStructure;

public record CompanyStructureResponse(
    List<Group> Locations);

public record Group(
    Guid Id,
    string Name,
    string CategoryName,
    List<Position> Positions,
    List<Group> ChildrenGroups);

public record Position(
    Guid Id,
    Guid RoleId,
    Guid WorkTypeId,
    string RoleName,
    string WorkType,
    string Type,
    string? FirstName,
    string? LastName,
    string? Patronymic);