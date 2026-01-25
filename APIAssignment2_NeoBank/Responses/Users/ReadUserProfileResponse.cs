using APIAssignment2_NeoBank.CORE;

namespace APIAssignment2_NeoBank.Responses.Users;

public class ReadUserProfileResponse : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string PhoneNumber { get; set; }

    public string Email { get; set; }
    public DateTime RegistrationDate { get; set; }
    public bool IsActive { get; set; }

    public bool Theme { get; set; }
    public string Language { get; set; }
    public bool PushNotificationsEnabled { get; set; }
}
