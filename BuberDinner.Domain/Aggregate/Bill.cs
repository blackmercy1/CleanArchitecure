using BuberDinner.Domain.Aggregate.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.GuestsAggregate.ValueObjects;
using BuberDinner.Domain.HostAggregate.ValueObjects;

namespace BuberDinner.Domain.Aggregate;

public class Bill : AggregateRoot<BillId>
{
    public DinnerId DinnerId { get; private set; }
    public GuestId GuestId { get; private set; }
    public HostId HostId { get; private set; }
    public Price Price { get; private set; }

    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    private Bill(
        BillId id,
        GuestId guestId,
        HostId hostId,
        Price price,
        DateTime createdDateTime,
        DateTime updatedDateTime)
        : base(id)
    {
        HostId = hostId;
        GuestId = guestId;
        Price = price;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Bill Create(
        GuestId guestId,
        HostId hostId,
        Price price)
    {
        return new Bill(
            BillId.CreateUnique(),
            guestId,
            hostId,
            price,
            DateTime.Now,
            DateTime.Now);
    }

#pragma warning disable CS8618
    private Bill() { }
#pragma warning restore CS8618
}