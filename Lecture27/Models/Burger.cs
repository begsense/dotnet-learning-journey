using Lecture27.CORE;

namespace Lecture27.Models;

internal class Burger : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public double Quantity { get; set; }
    public bool isActive { get; set; }
}
