using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Dinner.ValueObjects;

public sealed class Location : ValueObject
{
    public string Name { get; }
    public string Address { get; }
    public int Latitude { get; }
    public int Longitude { get; }

    private Location(
        string name,
        string address,
        int latitude,
        int longitude)
    {
        Name = name;
        Address = address;
        Latitude = latitude;
        Longitude = longitude;
    }
    public static Location CreateNewLocation(
        string name,
        string address,
        int latitude,
        int longitude)
    {
        return new Location(name, address, latitude, longitude);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Name;
        yield return Address;
        yield return Latitude;
        yield return Longitude;
    }


}