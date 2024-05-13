namespace BuberDinner.Contracts.Menus;

public record CreateMenuRequest(
    string Name,
    string Description,
    List<MenuSectionModel> Sections);

public record MenuSectionModel(
    string Name,
    string Description,
    List<MenuItemModel> Items);

public record MenuItemModel(
    string Name,
    string Description);