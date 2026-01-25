using APIAssignment2_NeoBank.CORE;

namespace APIAssignment2_NeoBank.Models;

public class PassportDetails : BaseEntity
{
    public string PersonalNumber { get; set; }
    public string DocumentNumber { get; set; }
    public DateTime ExpiryDate { get; set; }
    public string ImageStoragePath { get; set; }
    public int UserProfileId { get; set; }
    public UserProfile UserProfile { get; set; }
}
