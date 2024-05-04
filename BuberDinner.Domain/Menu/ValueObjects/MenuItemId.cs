using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Menu;

public sealed class MenuItemId : ValueObject
{
    public Guid Value { get;  }

    private MenuItemId(Guid value)
    {
        Value = value;
    }
    
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;   
    }
    
    public static MenuItemId CreateUnique() => new(Guid.NewGuid());
}