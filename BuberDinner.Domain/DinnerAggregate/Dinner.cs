using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.DinnerAggregate.Entities;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.HostAggregate.ValueObjects;
using BuberDinner.Domain.MenuAggregate.ValueObjects;

namespace BuberDinner.Domain.DinnerAggregate;

public class Dinner : AggregateRoot<DinnerId>
{
    private readonly List<Reservation> _reservations = new();
    
    public string Name { get;  private set;}
    public string Description { get;  private set;}
    public string Status { get; private set; }
    public bool IsPublic { get;  private set;}
    
    public int MaxGuest { get;  private set;}
    
    public Price Price { get; private set; }

    public HostId HostId { get;  private set;}
    public MenuId MenuId { get;  private set;}
    public string ImageUrl { get;  private set;}
    public Location Location { get; private set; }
    
    public DateTime StartDateTime { get;  private set;}
    public DateTime EndDateTime { get;  private set;}
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
    
#pragma warning disable CS8618
    private Dinner() { }
#pragma warning restore CS8618
}

public class Location
{
}