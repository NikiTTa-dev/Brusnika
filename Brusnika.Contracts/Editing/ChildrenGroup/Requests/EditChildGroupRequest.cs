namespace Brusnika.Contracts.Editing.ChildrenGroup.Requests;

public record EditChildGroupRequest(
    string Id,
    string CategoryName,
    string Name);
