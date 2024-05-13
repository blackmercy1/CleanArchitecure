using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.MenuReviewAggregate.ValueObjects;

public class MenuReviewId : ValueObject
{
    public Guid Value { get; }
    
    private MenuReviewId() { }

    private MenuReviewId(Guid value)
    {
        Value = value;
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static MenuReviewId CreateUnique() => new(Guid.NewGuid());
}