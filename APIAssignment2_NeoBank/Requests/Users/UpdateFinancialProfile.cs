namespace APIAssignment2_NeoBank.Requests.Users;

public class UpdateFinancialProfile
{
    public decimal MonthlyIncome { get; set; }
    public string SourceOfFunds { get; set; }
    public int RiskScore { get; set; }
}
