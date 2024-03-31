using ErrorOr;

namespace BuberDinner.Domain.Common.Errors;

public static partial class Errors
{
    public static class Authentication
    {
        public static Error InvalidCredentials => Error.Conflict(
            code: "Authentication invalid credentials",
            description: "Invalid credentials in authentication results");
    }
}