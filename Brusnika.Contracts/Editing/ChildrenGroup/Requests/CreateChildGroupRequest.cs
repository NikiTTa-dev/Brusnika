namespace Brusnika.Contracts.Editing.ChildrenGroup.Requests;

public record CreateChildGroupRequest(
    Guid ParentId,
    string CategoryName,
    string Name);