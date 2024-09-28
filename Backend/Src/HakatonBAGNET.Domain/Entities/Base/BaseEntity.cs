namespace HakatonBAGNET.Domain.Entities.Base;

public abstract class BaseEntity<TId>
{ 
    public TId Id { get; init; }
    
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
    
    public DateTime? UpdatedAt { get; set; }
    
    public bool IsDeleted { get; set; } = false;
    public DateTime? DeletedAt { get; set; }
}