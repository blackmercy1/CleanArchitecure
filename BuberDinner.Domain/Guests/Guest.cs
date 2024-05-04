using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Guests;

public sealed class Guest : AggregateRoot<GuestId>
{
    public Guest(GuestId id) : base(id)
    {
    }
}