using APIAssignment2_NeoBank.CORE;

namespace APIAssignment2_NeoBank.Models;

public class UserProfile: BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string PhoneNumber { get; set; }
    public UserAccount UserAccount { get; set; }
    public AppSettings AppSettings { get; set; }
    public FinancialProfile FinancialProfile { get; set; }
    public PassportDetails PassportDetails { get; set; }
}
