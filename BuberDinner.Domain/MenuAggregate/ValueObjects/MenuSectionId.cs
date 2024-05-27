using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.MenuAggregate.ValueObjects;

public sealed class MenuSectionId : AggregateRootId<Guid> 
{
    private MenuSectionId(Guid value) => Value = value;
    public override Guid Value { get; protected set; }
    public static MenuSectionId CreateUnique() => new(Guid.NewGuid());
    public static MenuSectionId Create(Guid value) => new(value);
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;   
    }
}
