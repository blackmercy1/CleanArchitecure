using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.DinnerAggregate.ValueObjects;

public sealed class DinnerId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }

    private DinnerId(Guid value) => Value = value;

    public static DinnerId CreateUnique() => new(Guid.NewGuid());
    public static DinnerId Create(Guid value) => new DinnerId(value);
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    private DinnerId() { }
}