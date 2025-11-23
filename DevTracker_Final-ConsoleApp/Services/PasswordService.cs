using BCrypt;

using DevTracker_Final_ConsoleApp.Interfaces;

namespace DevTracker_Final_ConsoleApp.Services;

internal class PasswordService : IPasswordService
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
