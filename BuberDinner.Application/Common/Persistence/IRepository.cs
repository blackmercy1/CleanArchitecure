namespace BuberDinner.Application.Common.Persistence;

public interface IRepository<T>
{
    void Add(T value);
    void Remove(T value);
    void Update(T value);
}