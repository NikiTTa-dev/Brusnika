namespace Brusnika.Contracts.CompanyStructure;

public record CompanyStructureResponse(
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
    string Type,
    string? FirstName,
    string? LastName,
    string? Patronymic,
    string WorkType);