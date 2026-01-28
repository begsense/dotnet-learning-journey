using Lecture31_One_To_Many.CORE;

namespace Lecture31_One_To_Many.Models;

public class BankAccount : BaseEntity
{
    public string IBAN { get; set; }
    public string CurrencyType { get; set; }
    public decimal Amount { get; set; }
    public bool IsActive { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
}
