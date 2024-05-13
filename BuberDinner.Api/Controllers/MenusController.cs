using BuberDinner.Application.Menus.Commands.CreateMenu;
using BuberDinner.Contracts.Menus;
using BuberDinner.Domain.MenuAggregate;
using BuberDinner.Domain.MenuAggregate.Entities;
using BuberDinner.Domain.MenuReviewAggregate.ValueObjects;

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
        Guid hostId)
    {
        var request = MapMenuRequest(menuRequest, hostId);
        var createMenuResult = await _mediator.Send(request);

        return createMenuResult.Match(
            menu => Ok(MapMenu(menu)),
            error => Problem(error));
    }

    private MenuResponse MapMenu(Menu menu)
    {
        return new MenuResponse(
            menu.Id.Value.ToString(),
            menu.Name,
            menu.Description,
            menu.AverageRating.NumRatings > 0 ? (float)menu.AverageRating.Value : null,
            MapSections(menu.Sections),
            MapMenuReviews(menu.MenuReviewIds),
            new DateTime(),
            new DateTime()
        );
    }

    private List<string> MapMenuReviews(IReadOnlyList<MenuReviewId> menuReviewIds)
    {
        var reviewIdList = new List<string>();
        
        for (var i = 0; i < menuReviewIds.Count; i++)
        
            reviewIdList.Add(menuReviewIds[i].Value.ToString());

        return reviewIdList;
    }

    private List<MenuSectionResponse> MapSections(IReadOnlyList<MenuSection> sections)
    {
        var menuSectionResponses = new List<MenuSectionResponse>();
        
        for (var i = 0; i < sections.Count; i++)
        {
            menuSectionResponses.Add(
                new MenuSectionResponse(
                    sections[i].Id.Value.ToString(),
                    sections[i].Name,
                    sections[i].Description,
                    MapMenuItemResponse(sections[i].Items)));
        }

        return menuSectionResponses;
    }

    private List<MenuItemResponse> MapMenuItemResponse(IReadOnlyList<MenuItem> items)
    {
        var menuItemsResponses = new List<MenuItemResponse>();
        
        for (var i = 0; i < items.Count; i++)
        {
            menuItemsResponses.Add(new MenuItemResponse(
                items[i].Id.Value.ToString(),
                items[i].Name,
                items[i].Description));
        }

        return menuItemsResponses;
    }

    private CreateMenuCommand MapMenuRequest(
        CreateMenuRequest menuRequest,
        Guid hostId)
    {
        return new CreateMenuCommand(
            hostId,
            menuRequest.Name,
            menuRequest.Description,
            MapMenuSectionRequest(menuRequest.Sections));
    }

    private List<MenuSectionCommand> MapMenuSectionRequest(List<MenuSectionModel> menuSections)
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

    private List<MenuItemCommand> MapMenuItemCommands(List<MenuItemModel> menuItems)
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