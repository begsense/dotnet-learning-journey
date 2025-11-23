using Lecture22.Enums;

namespace Lecture22.Models;

internal class User
{
    public string FullName { get; set; }
    public int Age { get; set; }
    public USER_ROLES Role { get; set; }
}
