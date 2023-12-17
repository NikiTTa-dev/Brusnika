namespace Brusnika.Contracts.Editing.ChildrenGroup.Requests;

public record RemoveChildFromParentsRequest(
    Guid ParentId,
    Guid ChildId);