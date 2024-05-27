using ErrorOr;

namespace BuberDinner.Domain.Common.Errors;

public static partial class Errors
{
     public static class User
     {
          public static Error DuplicateEmail => Error.Conflict(
               code: "UserAggregate.DuplicateEmail",
               description: "Current email is already exist");
     }
}