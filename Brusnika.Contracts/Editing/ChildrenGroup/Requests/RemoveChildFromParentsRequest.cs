namespace Brusnika.Contracts.Editing.ChildrenGroup.Requests;

public record RemoveChildFromParentsRequest(
    string ParentId,
    string ChildId);