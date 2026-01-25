using APIAssignment2_NeoBank.CORE;

namespace APIAssignment2_NeoBank.Responses.Users;

public class UpdateUserPassportDetailsResponse : BaseEntity
{
    public string PersonalNumber { get; set; }
    public string DocumentNumber { get; set; }
    public DateTime ExpiryDate { get; set; }
}
