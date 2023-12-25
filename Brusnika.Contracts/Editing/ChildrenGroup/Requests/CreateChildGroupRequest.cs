namespace Brusnika.Contracts.Editing.ChildrenGroup.Requests;

public record CreateChildGroupRequest(
    string CategoryName,
    string Name);