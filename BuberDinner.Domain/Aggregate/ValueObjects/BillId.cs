using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Aggregate.ValueObjects;

public sealed class BillId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }

    private BillId(Guid value)
    {
        Value = value;
    }

    public static BillId CreateUnique() => new(Guid.NewGuid());

    public static BillId Create(Guid value) => new(value);

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}