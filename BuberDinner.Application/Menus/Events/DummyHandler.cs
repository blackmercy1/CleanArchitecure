using BuberDinner.Domain.MenuAggregate.Events;

using MediatR;

namespace BuberDinner.Application.Menus.Events;

public class DummyHandler : INotificationHandler<MenuCreated>
{
    public Task Handle(MenuCreated menuCreated, CancellationToken cancellationToken )
    {
        Console.WriteLine("Hellops");
        return Task.CompletedTask;
    } 
}