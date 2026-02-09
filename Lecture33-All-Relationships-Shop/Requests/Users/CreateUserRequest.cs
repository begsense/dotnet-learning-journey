namespace Lecture33_All_Relationships_Shop.Requests.Users;

public class CreateUserRequest
{
    public string Email { get; set; }
    public string FullName { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
}
