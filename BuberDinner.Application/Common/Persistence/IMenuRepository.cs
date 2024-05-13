using BuberDinner.Domain.MenuAggregate;

namespace BuberDinner.Application.Common.Persistence;

public interface IMenuRepository
{
    void Add(Menu menu);
}