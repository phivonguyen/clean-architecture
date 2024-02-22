using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Common.ValueObjects;

public sealed class Rating : ValueObject
{
    public Rating(double value)
    {
        Value = value;
    }
    public double Value { get; }
    public static Rating CreateNew(double value = 0)
    {
        return new Rating(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}