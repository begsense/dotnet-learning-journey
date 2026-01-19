using BCrypt;
using APIAssignment1_Login_and_Register.Interfaces;

namespace APIAssignment1_Login_and_Register.Services;

public class PasswordService : IPasswordService
{
    public string Hash(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    public bool Verify(string password, string hash)
    {
        return BCrypt.Net.BCrypt.Verify(password, hash);
    }
}