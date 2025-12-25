using Lecture25.CORE;

namespace Lecture25.Models;

internal class Product : BaseEntity
{
    public string Title { get; set; }
    public int Quantity { get; set; }
    public bool IsActive { get; set; }
}
