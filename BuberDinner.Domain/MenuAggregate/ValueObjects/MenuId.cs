using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.MenuAggregate.ValueObjects;

public sealed class MenuId : ValueObject
{
    public Guid Value { get; }

    private MenuId(Guid value)
    {
        Value = value;
    }
    public static MenuId CreateUnique()
    {
        return new MenuId(Guid.NewGuid());
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
    public override string ToString()
    {
        return Value.ToString();
    }
}