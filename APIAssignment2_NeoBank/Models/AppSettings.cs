using APIAssignment2_NeoBank.CORE;

namespace APIAssignment2_NeoBank.Models;

public class AppSettings : BaseEntity
{
    public bool Theme { get; set; } = false;
    public string Language { get; set; } = "EN";
    public bool PushNotificationsEnabled { get; set; } = true;
    public int UserProfileId { get; set; }
    public UserProfile UserProfile { get; set; }
}
