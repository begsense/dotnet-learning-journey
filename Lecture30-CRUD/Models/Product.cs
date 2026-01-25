using Lecture30_CRUD.CORE;

namespace Lecture30_CRUD.Models;

public class Product : BaseEntity
{
    public string Title { get; set; }
    public decimal Price { get; set; }
}
