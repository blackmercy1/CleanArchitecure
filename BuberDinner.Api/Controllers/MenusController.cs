using BuberDinner.Application.Menus.Commands.CreateMenu;
using BuberDinner.Contracts.Menus;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[Route("/hosts/{hostId}/menus")]
public class MenusController : ApiController
{
    private readonly ISender _mediator;

    public MenusController(ISender mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateMenu(
        CreateMenuRequest menuRequest,
        string hostId)
    {
        var request = MapMenuRequest(menuRequest);
        var createMenuResult = await _mediator.Send(request);
        
        return Ok(createMenuResult);
    }

    private CreateMenuCommand MapMenuRequest(CreateMenuRequest menuRequest)
    {
        return new CreateMenuCommand(
            menuRequest.Name,
            menuRequest.Description,
            MapMenuSectionRequest(menuRequest.Sections));
    }

    private List<MenuSectionCommand> MapMenuSectionRequest(List<MenuSection> menuSections)
    {
        var menuSectionCommands = new List<MenuSectionCommand>();
        
        for (var i = 0; i < menuSections.Count; i++)
        { 
            menuSectionCommands.Add(new MenuSectionCommand(
                    menuSections[i].Name,
                    menuSections[i].Description,
                    MapMenuItemCommands(menuSections[i].Items)));
        }

        return menuSectionCommands;
    }

    private List<MenuItemCommand> MapMenuItemCommands(List<MenuItem> menuItems)
    {
        var menuItemCommand = new List<MenuItemCommand>();
        for (var i = 0; i < menuItems.Count; i++)
        { 
            menuItemCommand.Add(new MenuItemCommand(
                menuItems[i].Name,
                menuItems[i].Description));
        }

        return menuItemCommand;
    }
}