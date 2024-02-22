using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.HostAggregate.ValueObjects;

public sealed class HostId : ValueObject
{
    public Guid Value { get; }

    private HostId(Guid value)
    {
        Value = value;
    }
    public static HostId CreateUnique()
    {
        return new HostId(Guid.NewGuid());
    }

    // Factory method to create a HostId from a string
    public static HostId Create(string hostId)
    {
        if (!Guid.TryParse(hostId, out Guid result))
        {
            throw new ArgumentException("Invalid host ID format", nameof(hostId));
        }
        return new HostId(result);
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
