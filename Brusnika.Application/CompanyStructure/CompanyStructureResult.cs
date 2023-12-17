namespace Brusnika.Application.CompanyStructure;

public record CompanyStructureResult(
    List<Location> Locations);

public record Location(
    Guid Id,
    string Name,
    List<Position> Positions,
    List<FilialBranch> FilialBranches);

public record FilialBranch(
    Guid Id,
    string Name,
    List<Position> Positions,
    List<Subdivision> Subdivisions);
    
public record Subdivision(
    Guid Id,
    string Name,
    List<Position> Positions,
    List<Department> Departments);

public record Department(
    Guid Id,
    string Name,
    List<Position> Positions,
    List<Group> Group);

public record Group(
    Guid Id,
    string Name,
    List<Position> Positions);

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