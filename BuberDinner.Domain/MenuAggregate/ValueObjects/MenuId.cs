using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.MenuAggregate.ValueObjects;

public sealed class MenuId : AggregateRootId<Guid>
{
    private MenuId(Guid value) => Value = value;
    public override Guid Value { get; protected set; }
    public static MenuId CreateUnique() => new(Guid.NewGuid());
    public static MenuId Create(Guid value) => new(value);

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
    
    private MenuId() { }
}