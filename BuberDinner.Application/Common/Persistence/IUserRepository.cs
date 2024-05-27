using BuberDinner.Domain.UserAggregate;

namespace BuberDinner.Application.Common.Persistence;

public interface IUserRepository : IRepository<User>
{
    User? GetUserByEmail(string email);
}