using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Menu;

public sealed class MenuItem : Entity<MenuItemId>
{
    public MenuItemId MenuItemId { get; }
    public string Name { get; }
    public string Description { get; }

    private MenuItem(MenuItemId menuItemId, string name, string description)
        : base(menuItemId)
    {
        MenuItemId = menuItemId;
        Name = name;
        Description = description;
    }

    public static MenuItem Create(
        string name,
        string description)
    {
        return new MenuItem(MenuItemId.CreateUnique(), name, description);
    }
}