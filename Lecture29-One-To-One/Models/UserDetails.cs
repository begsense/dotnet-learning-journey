using Lecture29_One_To_One.CORE;

namespace Lecture29_One_To_One.Models;

public class UserDetails : BaseEntity
{
    public string WorkPlace {  get; set; }
    public string PhoneNumber { get; set; }
    public int UserId { get; set; }
    // navigation property
    public User User { get; set; }
}
