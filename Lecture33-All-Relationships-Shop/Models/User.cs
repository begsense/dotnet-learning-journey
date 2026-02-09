using Lecture33_All_Relationships_Shop.CORE;

namespace Lecture33_All_Relationships_Shop.Models;

public class User : BaseEntity
{
    public string Email { get; set; }
    public string FullName { get; set; }
    public UserDetails UserDetails { get; set; }
    public List<Order> Orders { get; set; }
}
