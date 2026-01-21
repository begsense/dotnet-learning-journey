using Lecture29_One_To_One.CORE;

namespace Lecture29_One_To_One.Models;

public class User : BaseEntity
{
    public string FullName { get; set; }
    public UserDetails UserDetails { get; set; }
}
