using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.MenuAggregate.ValueObjects;

public sealed class MenuSectionId : ValueObject 
{
    public Guid Value { get; private set; }

    private MenuSectionId(Guid value)
    {
        Value = value;
    }
    
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;   
    }
    
    public static MenuSectionId CreateUnique() => new(Guid.NewGuid());

    public static MenuSectionId Create(Guid value)
    {
        return new MenuSectionId(value);
    }
}