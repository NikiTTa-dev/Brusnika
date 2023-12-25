namespace Brusnika.Application.CompanyStructure;

public record CompanyStructureResult(
    List<GroupResult> Groups);

public record GroupResult(
    string Id,
    string Name,
    string CategoryName,
    List<PositionResult> Positions,
    List<GroupResult> ChildrenGroups);

public record PositionResult(
    string Id,
    string RoleName,
    string WorkType,
    string Type,
    string? FirstName,
    string? LastName,
    string? Patronymic);