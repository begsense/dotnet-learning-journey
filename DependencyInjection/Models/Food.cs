using DependencyInjection.CORE;

namespace DependencyInjection.Models;

public class Food : BaseEntity
{
    public string Name { get; set; }
    public decimal Price { get; set; }
}
