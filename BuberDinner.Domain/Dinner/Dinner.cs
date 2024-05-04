using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.Entities;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu;

namespace BuberDinner.Domain.Dinner;

public class Dinner : AggregateRoot<DinnerId>
{
    private readonly List<Reservation> _reservations = new();
    
    public string Name { get; }
    public string Description { get; }
    public string Status { get; }
    public bool IsPublic { get; }
    
    public int MaxGuest { get; }
    
    public Price Price { get; }

    public HostId HostId { get; }
    public MenuId MenuId { get; }
    public string ImageUrl { get; }
    public Location Location { get; }
    
    public DateTime StartDateTime { get; }
    public DateTime EndDateTime { get; }
    public DateTime? StartedDateTime { get; private set; }
    public DateTime? EndedDateTine { get; private set; }

    public IReadOnlyList<Reservation> Reservations => _reservations.AsReadOnly();
    
    private Dinner(
        DinnerId id,
        string name,
        string description,
        string status,
        bool isPublic,
        int maxGuest,
        Price price,
        HostId hostId,
        MenuId menuId,
        string imageUrl,
        Location location,
        DateTime startDateTime,
        DateTime endDateTime) : base(id)
    {
        Name = name;
        Description = description;
        Status = status;
        IsPublic = isPublic;
        MaxGuest = maxGuest;
        Price = price;
        HostId = hostId;
        MenuId = menuId;
        ImageUrl = imageUrl;
        Location = location;
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
    }

    public static Dinner Create(
        string name,
        string description,
        string status,
        bool isPublic,
        int maxGuests,
        DateTime startDateTime,
        DateTime endDateTime,
        Price price,
        HostId hostId,
        MenuId menuId,
        string imageUrl,
        Location location)
    {
        return new(
            DinnerId.CreateUnique(),
            name,
            description,
            status,
            isPublic,
            maxGuests,
            price,
            hostId,
            menuId,
            imageUrl,
            location,
            DateTime.Now,
            DateTime.Now);
    }
}

public class Location
{
}