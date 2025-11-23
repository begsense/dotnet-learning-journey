using DevTracker_Final_ConsoleApp.Enums;

namespace DevTracker_Final_ConsoleApp.Models;

internal class User
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public USER_ROLE Role { get; set; }
}
