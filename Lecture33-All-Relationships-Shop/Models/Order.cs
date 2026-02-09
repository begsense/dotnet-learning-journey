using Lecture33_All_Relationships_Shop.CORE;

namespace Lecture33_All_Relationships_Shop.Models;

public class Order : BaseEntity
{
    public DateTime OrderDate { get; set; }
    public int Quantity { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; }
}
