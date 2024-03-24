using BuberDinner.Application.Common.Persistence;
using BuberDinner.Domain.Entities;

namespace BuberDinner.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    private static readonly List<User> _users = new();

    public void Add(User value) => _users.Add(value);
    public void Remove(User value) => throw new NotImplementedException();
    public void Update(User value) => throw new NotImplementedException();
    public User? GetUserByEmail(string email) => _users.SingleOrDefault(user => user.Email == email);
}