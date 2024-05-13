using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.HostAggregate.ValueObjects;

public class HostId : ValueObject
{
    public Guid Value { get; }

    private HostId() { }
    private HostId(Guid value) => Value = value;

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static HostId Create(Guid value) => new HostId(value);
    public static HostId CreateUnique() => new (Guid.NewGuid());
    
}