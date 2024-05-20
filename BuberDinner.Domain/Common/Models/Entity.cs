namespace BuberDinner.Domain.Common.Models;

public abstract class Entity<TId> : IEquatable<Entity<TId>>
    where TId : notnull
{
    public TId Id { get; protected init; }

    protected Entity(TId id) => Id = id;

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) 
            return false;
        if (ReferenceEquals(this, obj)) 
            return true;
        
        return obj.GetType() == this.GetType() && Equals((Entity<TId>) obj);
    }

    public static bool operator ==(Entity<TId> left, Entity<TId> right) => Equals(left, right);
    public static bool operator !=(Entity<TId> left, Entity<TId> right) => Equals(left, right);
    public bool Equals(Entity<TId>? other) => Equals((object?) other);
    public override int GetHashCode() => Id.GetHashCode();

#pragma warning disable CS8618
    protected Entity() { }
#pragma warning restore CS8618
}