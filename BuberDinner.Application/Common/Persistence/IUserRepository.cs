using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Common.Persistence;

public interface IUserRepository : IRepository<User>
{
    User? GetUserByEmail(string email);
}