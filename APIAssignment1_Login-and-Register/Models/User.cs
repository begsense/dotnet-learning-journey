using APIAssignment1_Login_and_Register.Core;

namespace APIAssignment1_Login_and_Register.Models;

public class User : BaseEntity
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}
