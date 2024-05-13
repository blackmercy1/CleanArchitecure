using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.DinnerAggregate.ValueObjects;

public class DinnerId : ValueObject
{
    public Guid Value { get; }

    private DinnerId(Guid value)
    {
        Value = value;
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static DinnerId CreateUnique() => new(Guid.NewGuid());
    public static DinnerId Create(Guid value) => new DinnerId(value);

    private DinnerId() { }
}