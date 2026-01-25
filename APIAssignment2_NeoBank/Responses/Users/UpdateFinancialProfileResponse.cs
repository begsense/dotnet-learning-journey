using APIAssignment2_NeoBank.CORE;

namespace APIAssignment2_NeoBank.Responses.Users;

public class UpdateFinancialProfileResponse : BaseEntity
{
    public decimal MonthlyIncome { get; set; }
    public string SourceOfFunds { get; set; }
    public int RiskScore { get; set; }
}
