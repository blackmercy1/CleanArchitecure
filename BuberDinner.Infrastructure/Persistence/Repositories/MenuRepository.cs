using BuberDinner.Application.Common.Persistence;
using BuberDinner.Domain.MenuAggregate;

namespace BuberDinner.Infrastructure.Persistence;

public class MenuRepository : IMenuRepository
{
    private readonly MenuDatabaseContext _context;

    public MenuRepository(MenuDatabaseContext context)
    {
        _context = context;
    }
    
    public void Add(Menu menu)
    {
        _context.Add(menu);
        _context.SaveChanges();
    }
}