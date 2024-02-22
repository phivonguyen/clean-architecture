using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.DinnerAggregate.ValueObjects;

public sealed class Price : ValueObject
{
    public int Amount { get; }
    public string Currency { get; }
    private Price(int amount, string currency)
    {
        Amount = amount;
        Currency = currency;
    }
    public static Price CreateNewPrice(int amount, string currency)
    {
        return new Price(amount, currency);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Amount;
        yield return Currency;
    }
}
