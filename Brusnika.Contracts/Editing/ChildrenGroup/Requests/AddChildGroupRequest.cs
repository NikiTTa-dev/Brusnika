namespace Brusnika.Contracts.Editing.ChildrenGroup.Requests;

public record AddChildGroupRequest(
    string ParentId,
    string ChildId);