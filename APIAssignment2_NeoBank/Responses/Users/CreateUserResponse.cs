using APIAssignment2_NeoBank.CORE;

namespace APIAssignment2_NeoBank.Responses.Users;

public class CreateUserResponse : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
