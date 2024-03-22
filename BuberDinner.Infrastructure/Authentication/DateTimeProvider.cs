using BuberDinner.Application.Common.Interfaces.Services;

namespace BuberDinner.Infrastructure.Authentication;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.Now;
}