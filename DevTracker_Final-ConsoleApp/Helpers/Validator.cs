using System.Text.RegularExpressions;

namespace DevTracker_Final_ConsoleApp.Helpers;

internal class Validator
{
    private bool IsValidEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            return false;
        }

        string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

        return Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase);
    }

    private bool IsValidUsername(string username)
    {
        if (string.IsNullOrWhiteSpace(username))
        {
            return false;
        }

        string pattern = @"^[a-zA-Z0-9]{3,20}$";

        return Regex.IsMatch(username, pattern);
    }

    private bool IsValidPassword(string password)
    {
        if (string.IsNullOrWhiteSpace(password))
        {
            return false;
        }

        string pattern = @"^(?=.*[A-Za-z])(?=.*\d).{6,}$";

        return Regex.IsMatch(password, pattern);
    }

    public bool ValidateSignUp(string email, string username, string password, out string errorMessage)
    {
        if (!IsValidEmail(email))
        {
            errorMessage = "Invalid email format.";
            return false;
        }

        if (!IsValidUsername(username))
        {
            errorMessage = "Username must be 3-20 characters, letters and numbers only.";
            return false;
        }

        if (!IsValidPassword(password))
        {
            errorMessage = "Password must be at least 6 characters with at least 1 letter and 1 number.";
            return false;
        }

        errorMessage = string.Empty;
        return true;
    }
}
