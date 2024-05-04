using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Menu;

public sealed class MenuSectionId : ValueObject 
{
    public Guid Value { get;  }

    private MenuSectionId(Guid value)
    {
        Value = value;
    }
    
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;   
    }
    
    public static MenuSectionId CreateUnique() => new(Guid.NewGuid());
}