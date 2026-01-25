using APIAssignment2_NeoBank.CORE;

namespace APIAssignment2_NeoBank.Models;

public class UserAccount : BaseEntity
{
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public DateTime RegistrationDate { get; set; }
    public bool IsActive { get; set; }
    public int UserProfileId { get; set; }
    public UserProfile UserProfile { get; set; }
}
