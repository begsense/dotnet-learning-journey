using Lecture25.CORE;

namespace Lecture25.Models;

internal class User : BaseEntity
{
    public string UserName { get; set; }
    // Stored Hashed Via Bcrypt
    public string Password { get; set; }
    public bool IsDeleted { get; set; } = false;
}
