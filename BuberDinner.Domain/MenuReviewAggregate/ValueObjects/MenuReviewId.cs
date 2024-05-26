using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.MenuReviewAggregate.ValueObjects;

public sealed class MenuReviewId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }
    
    private MenuReviewId() { }

    private MenuReviewId(Guid value)
    {
        Value = value;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static MenuReviewId CreateUnique() => new(Guid.NewGuid());
}