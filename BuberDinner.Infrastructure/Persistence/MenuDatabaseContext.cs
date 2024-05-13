using BuberDinner.Domain.MenuAggregate;
using Microsoft.EntityFrameworkCore;

namespace BuberDinner.Infrastructure.Persistence;

public class MenuDatabaseContext : DbContext
{
    public MenuDatabaseContext() { }
    
    public MenuDatabaseContext(DbContextOptions<MenuDatabaseContext> options)
        : base(options)
    {

    }

    public DbSet<Menu> Menus { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MenuDatabaseContext).Assembly); 
    }
}