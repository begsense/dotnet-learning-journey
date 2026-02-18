using Lecture36_Auth.CORE;

namespace Lecture36_Auth.Models;

public class User : BaseEntity
{
    public string Email { get; set; }
    // Hashed via Bcrypt
    public string Password { get; set; }
}
