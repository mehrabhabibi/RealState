namespace RealState.Domain.Entities.Common;

public abstract class EntityBase
{
    public int Id { get; set; }
    public bool Active { get; set; } = true;
    public bool Deleted { get; set; } = false;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? ModifiedAt { get; set; }
}