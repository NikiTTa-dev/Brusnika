namespace Brusnika.Contracts.CompanyStructure;

public record CompanyStructureResponse(
    List<Group> Groups);

public record Group(
    string Id,
    string Name,
    string CategoryName,
    List<Position> Positions,
    List<Group> ChildrenGroups);

public record Position(
    string Id,
    string RoleName,
    string WorkType,
    string Type,
    string? FirstName,
    string? LastName,
    string? Patronymic);