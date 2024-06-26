using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.MenuAggregate.ValueObjects;

public sealed class AverageRating : ValueObject
{
    private AverageRating(double value, int numRatings)
    {
        Value = value;
        NumRatings = numRatings;
    }

    public double Value { get; private set; }
    public int NumRatings { get; private set; }

    public static AverageRating CreateNew(double rating = 0, int numRatings = 0) => new(rating, numRatings);

    public void AddNewRating(Rating rating) => Value = ((Value * NumRatings) + rating.Value) / ++NumRatings;

    public void RemoveRating(Rating rating) => Value = ((Value * NumRatings) - rating.Value) / --NumRatings;

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}