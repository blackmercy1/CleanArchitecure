using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.UserAggregate.ValueObjects;

public sealed class UserId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }

    private UserId(Guid value) => Value = value;

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;   
    }
    
    public static UserId CreateUnique() => new(Guid.NewGuid());
}