using APIAssignment2_NeoBank.CORE;

namespace APIAssignment2_NeoBank.Models;

public class FinancialProfile : BaseEntity
{
    public decimal MonthlyIncome { get; set; }
    public string SourceOfFunds { get; set; }
    public int RiskScore { get; set; }
    public int UserProfileId { get; set; }
    public UserProfile UserProfile { get; set; }
}
