using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.MenuAggregate;
using BuberDinner.Infrastructure.Persistence.Interceptors;

using Microsoft.EntityFrameworkCore;

namespace BuberDinner.Infrastructure.Persistence;

public sealed class MenuDatabaseContext : DbContext
{
    public DbSet<Menu> Menus { get; set; } = null!;

    private readonly PublishDomainEventsInterceptor _publishDomainEventsInterceptor;
    
    public MenuDatabaseContext(
        DbContextOptions<MenuDatabaseContext> options, 
        PublishDomainEventsInterceptor publishDomainEventsInterceptor)
        : base(options)
    {
        _publishDomainEventsInterceptor = publishDomainEventsInterceptor;
        Database.EnsureDeleted();
        Database?.EnsureCreated();
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Ignore<List<IDomainEvent>>()
            .ApplyConfigurationsFromAssembly(typeof(MenuDatabaseContext).Assembly);
        
        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_publishDomainEventsInterceptor);
        base.OnConfiguring(optionsBuilder);
    }
}