namespace Lecture36_Auth.CORE;

public class BaseEntity
{
    public int Id { get; set; } 
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; }
}
