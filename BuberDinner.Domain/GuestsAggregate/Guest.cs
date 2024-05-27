using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.GuestsAggregate.ValueObjects;

namespace BuberDinner.Domain.GuestsAggregate;

public sealed class Guest : AggregateRoot<GuestId>
{
    public Guest(GuestId id) : base(id)
    {
    }
    
#pragma warning disable CS8618
    private Guest() { }
#pragma warning restore CS8618
}