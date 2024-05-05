using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.MenuAggregate.ValueObjects;

namespace BuberDinner.Domain.MenuAggregate.Entities;

public sealed class MenuSection : Entity<MenuSectionId>
{
    private readonly List<MenuItem> _itemsMenu = new();  
    public string Name { get; }
    public string Description { get; }

    public IReadOnlyList<MenuItem> Items => _itemsMenu.AsReadOnly();

    private MenuSection(
        MenuSectionId menuSectionId,
        string name,
        string description) :
        base(menuSectionId)
    {
        Name = name;
        Description = description;
    }
}