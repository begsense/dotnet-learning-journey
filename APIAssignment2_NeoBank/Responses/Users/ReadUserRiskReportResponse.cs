using APIAssignment2_NeoBank.CORE;

namespace APIAssignment2_NeoBank.Responses.Users;

public class ReadUserRiskReportResponse : BaseEntity
{
    public decimal MonthlyIncome { get; set; }
    public string SourceOfFunds { get; set; }
    public int RiskScore { get; set; }
    public string PersonalNumber { get; set; }
    public string DocumentNumber { get; set; }
    public DateTime ExpiryDate { get; set; }
    public string ImageStoragePath { get; set; }
}
