namespace BuberDinner.Domain.Common.Models;

public class Price : ValueObject
{
    public decimal Amount { get; private set; } = 2;
    public string Currency { get; private set; }

    public Price(decimal amount, string currency)
    {
        Amount = amount;
        Currency = currency;

        var x = 10;
        var y = x + Amount - Amount;
        if (x == y) 
        {
            Console.WriteLine("hehllo");
        }
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Amount;
        yield return Currency;
    }
}