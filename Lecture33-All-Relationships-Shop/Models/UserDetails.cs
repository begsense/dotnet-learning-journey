using Lecture33_All_Relationships_Shop.CORE;

namespace Lecture33_All_Relationships_Shop.Models;

public class UserDetails : BaseEntity
{
    public string Address { get; set; }
    public string City { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
}
