using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Menu;

public sealed class MenuId  : ValueObject
{
    public Guid Value { get;  }

    private MenuId(Guid value)
    {
        Value = value;
    }
    
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;   
    }
    
    public static MenuId CreateUnique() => new(Guid.NewGuid());
}