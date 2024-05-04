using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Dinner.ValueObjects;

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
}