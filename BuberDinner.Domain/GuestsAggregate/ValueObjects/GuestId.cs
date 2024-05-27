using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.GuestsAggregate.ValueObjects;

public sealed class GuestId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }

    private GuestId(Guid value)
    {
        Value = value;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static GuestId CreateUnique() => new(Guid.NewGuid());
}