namespace APIAssignment2_NeoBank.Requests.Users;

public class UpdateUserPassportDetails
{
    public string PersonalNumber { get; set; }
    public string DocumentNumber { get; set; }
    public string ImageStoragePath { get; set; }
    public DateTime ExpiryDate { get; set; }
}
