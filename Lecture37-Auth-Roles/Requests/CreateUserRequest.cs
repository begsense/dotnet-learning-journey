namespace Lecture37_Auth_Roles.Requests;

public class CreateUserRequest
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
}
