using Lecture33_All_Relationships_Shop.CORE;

namespace Lecture33_All_Relationships_Shop.Models;

public class Category : BaseEntity
{
    public string Name { get; set; }
    public List<Product> Products { get; set; }
}
