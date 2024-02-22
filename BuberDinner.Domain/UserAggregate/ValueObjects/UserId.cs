using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.UserAggregate.ValueObjects;

public class UserId : ValueObject
{
    public Guid Value { get; }
    public UserId(Guid value)
    {
        Value = value;
    }
    public static UserId CreateUnique()
    {
        return new UserId(Guid.NewGuid());
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
