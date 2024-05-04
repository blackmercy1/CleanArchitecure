using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.GuestsAggregate.ValueObjects;

namespace BuberDinner.Domain.GuestsAggregate;

public sealed class Guest : AggregateRoot<GuestId>
{
    public Guest(GuestId id) : base(id)
    {
    }
}