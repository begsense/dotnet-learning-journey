namespace Lecture31_One_To_Many.Responses.BankAccounts;

public class BankAccountResponse
{
    public string IBAN { get; set; }
    public string CurrencyType { get; set; }
    public decimal Amount { get; set; }
}
