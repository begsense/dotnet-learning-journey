using Lecture37_Auth_Roles.CORE;

namespace Lecture37_Auth_Roles.Models;

public class User : BaseEntity
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
}
