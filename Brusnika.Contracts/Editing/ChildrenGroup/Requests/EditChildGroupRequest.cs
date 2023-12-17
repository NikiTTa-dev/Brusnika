namespace Brusnika.Contracts.Editing.ChildrenGroup.Requests;

public record EditChildGroupRequest(
    Guid ChildGroupId,
    Guid ParentId,
    string CategoryName,
    string Name);
