namespace Lecture31_One_To_Many.Responses.Users;
using Lecture31_One_To_Many.Responses.BankAccounts;

public class GetFullUserResponse
{
    public string FirstName { get; set; }
    public List<BankAccountResponse> BankAccounts { get; set; } = new List<BankAccountResponse>();
}
