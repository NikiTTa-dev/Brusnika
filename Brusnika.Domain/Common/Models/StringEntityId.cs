namespace Brusnika.Domain.Common.Models;

public class StringEntityId<TId> : ValueObject
    where TId: StringEntityId<TId>
{
    public string Value { get; private set; }

    protected StringEntityId(string value)
    {
        Value = value;
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}