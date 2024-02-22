using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Guest.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;

namespace BuberDinner.Domain.Guest.Entities;

public sealed class GuestRating : Entity<GuestRatingId>
{
    public HostId HostId { get; }
    public DinnerId DinnerId { get; }
    public float Rating { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    private GuestRating(
        GuestRatingId guestRatingId,
        HostId hostId,
        DinnerId dinnerId,
        float rating,
        DateTime createDateTime,
        DateTime updatedDateTime) : base(guestRatingId)
    {
        HostId = hostId;
        DinnerId = dinnerId;
        Rating = rating;
        CreatedDateTime = createDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static GuestRating Create(
        HostId hostId,
        DinnerId dinnerId,
        float rating
    )
    {
        return new GuestRating(
            GuestRatingId.CreateUnique(),
            hostId,
            dinnerId,
            rating,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }
}