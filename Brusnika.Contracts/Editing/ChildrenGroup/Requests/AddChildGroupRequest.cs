namespace Brusnika.Contracts.Editing.ChildrenGroup.Requests;

public record AddChildGroupRequest(
    Guid ParentId,
    Guid ChildId);