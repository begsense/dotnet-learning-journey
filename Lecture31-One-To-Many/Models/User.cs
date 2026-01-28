using Lecture31_One_To_Many.CORE;

namespace Lecture31_One_To_Many.Models;

public class User : BaseEntity
{
    public string FirstName { get; set; }
    public string Email { get; set; }
    public List <BankAccount> BankAccounts { get; set; }
}
