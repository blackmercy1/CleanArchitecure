using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.MenuAggregate.ValueObjects;

public sealed class Rating : ValueObject
{
    public double Value { get; private set; }

    private Rating(double value)
    {
        Value = value;
    }

    public static Rating CreateNew(double value)
    {
        return new(value);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}