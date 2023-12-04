namespace Brusnika.Contracts.Editing.Children.Requests;

public record CreateChildRequest(
    Guid ParentId,
    string Name);