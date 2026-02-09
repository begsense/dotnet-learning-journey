using Lecture33_All_Relationships_Shop.CORE;

namespace Lecture33_All_Relationships_Shop.Models;

public class Product : BaseEntity
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public List<Category> Categories { get; set; }
}
