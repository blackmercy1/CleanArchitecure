using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.UserAggregate.ValueObjects;

public class UserId : ValueObject
{
    public Guid Value { get;  }

    private UserId(Guid value)
    {
        Value = value;
    }
    
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;   
    }
    
    public static UserId CreateUnique() => new(Guid.NewGuid());
}