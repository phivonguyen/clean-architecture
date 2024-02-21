namespace BuberDinner.Domain.Common.Models;

public abstract class AggregateRoot : Entity<int>
{
    protected AggregateRoot(int id) : base(id)
    {
    }
}
