namespace Lecture31_One_To_Many.Requests.BankAccount;

public class CreateBankAccountRequest
{
    public string IBAN { get; set; }
    public string CurrencyType { get; set; }
    public int UserId { get; set; }
}
