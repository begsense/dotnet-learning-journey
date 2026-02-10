using Lecture34_AutoMapper.CORE;

namespace Lecture34_AutoMapper.Models;

public class Product : BaseEntity
{
    public string Title { get; set; }
    public decimal Price { get; set; }
    public int Amount { get; set; }
    public string Description { get; set; }
    public string AdminOnly { get; set; }
}
