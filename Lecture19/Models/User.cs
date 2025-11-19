namespace Lecture19.Models;

internal class User
{
    public string Email { get; set; }

    public string Password { get; set; }

    public DateTime RegisteredAt { get; set; }

    public bool IsActive { get; set; }

    public string ActivationCode { get; set; }
}