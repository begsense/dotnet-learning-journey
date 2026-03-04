using Microsoft.AspNetCore.Mvc;

namespace DependencyInjection.CORE;

public class BaseEntity
{
    public int Id { get; set; } 
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; }
}
